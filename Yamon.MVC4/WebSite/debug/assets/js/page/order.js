function formatCurrency(value) {
	return value.toFixed(2);
}
var indexViewModel = function() {
	var self = this;
	//js初始化
	self.init = function() {
		jQuery("#vbookd").removeClass("active");
		if($.cookie('__isMemberLogin') != null) {
			var time = new Date();
			var times = time.getFullYear() + "-" + (time.getMonth() + 1) + "-" + time.getDate()

			jQuery("#MakeTime").val(times)
			$('#sample-table-2').rowspan(0); //传入的参数是对应的列数从0开始，哪一列有相同的内容就输入对应的列数值
			GetProductInfolist();

		} else {
			alert("请先登录!")
			window.location.href = "Login.html"
		}

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

		return self.SalePrice() * self.Num();
	});

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

		// alert(orderInfo)
		// ko.utils.postJson($("form")[0], orderInfo);

		if(types) {

			YamonAPI.POST('/api/Product/ProductBook/Create', orderInfo, function(msg) {
				if(msg.success) {
					alert("预约成功")
					window.location.href = "orderlist.html";
					// window.location.reload();
				} else {
					alert("提交失败");
				}
			});
		} else {
			alert("请选择票数！");
		}
	};
}

function GetProductInfolist() {
	YamonAPI.POST('/api/Product/VProductInfo/GetProductListByModels', function(result) {
		var cartList = [];
		for(var i = 0; i < result.length; i++) {
			cartList.push(new CartLine(result[i]));
		}
		ko.applyBindings(new index(cartList));
		$('#sample-table-2').rowspan(0);
		$("input[class='Num']").TouchSpin();
	});
}