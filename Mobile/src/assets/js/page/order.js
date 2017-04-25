function formatCurrency(value) {
	return value.toFixed(2);
}
var indexViewModel = function() {
	var self = this;
	var url = 'http://www.shlycmuseum.com';
	self.listLink = ko.observableArray([]);
	
	//js初始化
	self.init = function() {
		if($.cookie('__isMemberLogin') != null) {
			var time = new Date();
			var times = time.getFullYear() + "-" + (time.getMonth() + 1) + "-" + time.getDate();
			jQuery("#MakeTime").val(times);
			$('#sample-table-2').rowspan(0);
			GetProductInfolist();
			self.linkList();
		} else {
			$.toast.prototype.duration = '2000';
			$.toast('请先登录');
			window.location.href = "login.html";
		}
	}
	
	//友情鏈接
	self.linkList = function() {
		$.ajax({
			type: "get",
			url: url + "/api.aspx",
			data: {
				action: 'GetLINKSList',
			},
			dataType: "JSON",
			success: function(msg) {
				self.listLink.removeAll();
				for(var i = 0; i < msg.data.length; i++) {
					self.listLink.push(msg.data[i]);
				}
			}
		});
	}
}
var CartLine = function(obj) {
	var self = this;
	self.ProductName = ko.observable(obj.ProductName);
	self.SalePrice = ko.observable(obj.SalePrice);
	self.TypeName = ko.observable(obj.TypeName);
	self.ProductID = ko.observable(obj.ProductInfoId);
	self.ProductNo = ko.observable(obj.ProductInfoNo);
	self.Num = ko.observable(0);
	self.TotalMoney = ko.pureComputed(function() {
		if(self.Num() == '' || self.Num() < 0) {
			self.Num(0);
		} else if(self.Num() > 100) {
			self.Num(100);
		}
		return self.SalePrice() * self.Num();
	});
	self.numMinus = function() {
		self.Num(self.Num() - 1);
	}
	self.numAdd = function() {
		self.Num(self.Num() + 1);
	}
};
var index = function(result) {
	var self = this;
	self.lines = ko.observableArray(result);
	self.grandTotal = ko.pureComputed(function() {
		var total = 0;
		$.each(self.lines(), function(i) {
			total += self.lines()[i].SalePrice() * self.lines()[i].Num()
		})
		return total;
	});
	self.save = function(from) {
		//商品列表信息
		var types = false;
		var dataToSave = $.map(self.lines(), function(line) {
			if(line.Num() != "0") {
				types = true;
				return [{
					ProductID: line.ProductID(),
					ProductNo: line.ProductNo(),
					Price: line.SalePrice(),
					Num: line.Num(),
					TotalMoney: parseFloat(line.Num()) * parseFloat(line.SalePrice()),
					MakeTime: jQuery("#MakeTime").val(),
					SalePrice: line.SalePrice()
				}];
			}
		}); 
		//会员信息
		var orderInfo = {
			TotalMoney: $("#TotalMoney").text(),
			Models: "Ticket",
			MakeTime: jQuery("#MakeTime").val()
		};
		orderInfo.json = ko.utils.stringifyJson(dataToSave);
		var day = new Date().getDate(),
			hour = new Date().getHours(),
			month = new Date().getMonth() + 1,
			time = $('#MakeTime').val().split('-')[2],
			month2 = $('#MakeTime').val().split('-')[1];
 
		if(types) {
			if(hour >= 16) {
				if(month2 > month ||(month2 == month && time>= day + 2)) {
					YamonAPI.POST('/api/Product/ProductBook/Create', orderInfo, function(msg) {
						if(msg.success) {
							$.toast.prototype.duration = '2000';
							$.toast('预约成功');
							window.location.href = "orderlist.html";
						} else { 
							$.toast.prototype.duration = '2000';
							$.toast('预约失败');
						}
					});
				} else {
					$.toast.prototype.duration = '3000';
					$.toast('请预约第二天以后的门票');
				}
			} else {
				if(month2 > month ||(month2 == month && time>= day + 1)) {
					YamonAPI.POST('/api/Product/ProductBook/Create', orderInfo, function(msg) {
						if(msg.success) {
							$.toast.prototype.duration = '2000';
							$.toast('预约成功');
							window.location.href = "orderlist.html";
						} else {
							$.toast.prototype.duration = '2000';
							$.toast('预约失败');
						}
					});
				}else{
					$.toast.prototype.duration = '3000';
					$.toast('请预约明天及以后的门票');
				}
			}
		} else {
			$.toast.prototype.duration = '2000';
			$.toast('请选择票数');
		}
	};
}

function GetProductInfolist() {
	YamonAPI.POST('/api/Product/VProductInfo/GetProductListByModels', function(result) {
		var cartList = [];
		for(var i = 0; i < result.rows.length; i++) {
			cartList.push(new CartLine(result.rows[i]));
		}
		ko.applyBindings(new index(cartList));
		$('#sample-table-2').rowspan(0);
	});
}