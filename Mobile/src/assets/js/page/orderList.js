var index = function(result) {
	var self = this;
	self.lines = ko.observableArray(result);
	self.TotalMoney = ko.observableArray();
	var url = 'http://www.shlycmuseum.com';

	self.listLink = ko.observableArray([]);

	self.init = function() {
		if($.cookie('__isMemberLogin') != null) {
			GetProductBookList();
			self.linkList();
		} else {
			$.toast.prototype.duration = '2000';
			$.toast('请先登录');
			window.location.href = "login.html"
		}
	}

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
		})
	}
}

function GetProductBookList() {
	YamonAPI.POST('/api/Product/VProductBook/GetProductBookList', function(result) {
		if(result.TotalMoney) {
			self.TotalMoney = result.TotalMoney;
		} else {
			self.TotalMoney = 0;
		}
		GetProductBookDetailList(result);
	});
}

function GetProductBookDetailList(productBook) {
	YamonAPI.POST('/api/Product/VProductBookDetail/GetProductBookDetailList', function(result) {
		for(var j = 0; j < productBook.length; j++) {
			productBook[j].products = [];
			for(var i = 0; i < result.length; i++) {
				if(result[i].ProductBookID == productBook[j].ProductBookID) {
					productBook[j].products.push(result[i]);
				}
			}
		}
		productBook.allproducts = result;
		var indexModel = new index(productBook);
		ko.applyBindings(indexModel);
	});
}