var link = function() {
	var this = self;
	var url = 'http://www.shlycmuseum.com';
	self.listLink = ko.observableArray([]);
	
	self.init = function() {
		self.linkList();
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