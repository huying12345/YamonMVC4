var keyWordsViewModel = function() {
	var self = this;
	var url = 'http://www.shlycmuseum.com';

	self.keywordList = ko.observableArray([]);
	self.init = function() {
		self.getKeyWords();
	}
	self.getKeyWords = function() {
		$.ajax({
			type: "get",
			url: url + "/api.aspx",
			dataType: 'JSON',
			data: {
				action: 'search',
				keyword:decodeURI($.getUrlVar('keyword'))
			},
			success: function(msg) {
				self.keywordList.removeAll();
				for(var i = 0; i < msg.data.length; i++) {
					self.keywordList.push(msg.data[i]);
				}
			}
		});
	}
}