var coopViewModel = function() {
	var self = this;
	var url = 'http://www.shlycmuseum.com';

	self.listLink = ko.observableArray([]);
	self.linkShop = ko.observableArray([]);

	self.init = function() {
		self.linkList();
		self.shopLink();
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
		//微店
	self.shopLink = function() {
		$.ajax({
			type: "get",
			url: url + "/api.aspx",
			data: {
				action: "GetNewsTreeList",
				NewsCode: "1120220220"
			},
			success: function(msg) {
				self.linkShop.removeAll();
				for(var i = 0; i < msg.data.length; i++) {
					self.linkShop.push(msg.data[i]);
				}
			}
		});
	}
}