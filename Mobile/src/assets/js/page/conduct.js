var CarViewModel = function() {
	var self = this;
	var url = 'http://www.shlycmuseum.com';
	self.listcarculture1 = ko.observableArray([]);
	self.listcarculture4 = ko.observableArray([]);
	self.listLink = ko.observableArray([]);
	self.linkShop = ko.observableArray([]);

	self.pageList = ko.observableArray([]);
	self.color = ko.observable();

	self.init = function() {
			self.GetCarxuanchuan(0);
			self.GetCarmedia();
			self.linkList();
			self.shopLink();
		}
		//宣传展示
	self.GetCarxuanchuan = function(page) {
			self.Information(2057566403, 1152326198, self.listcarculture1, page);
		}
		//媒体中心
	self.GetCarmedia = function() {
		self.Information(2057566403, 1280315735, self.listcarculture4);
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
		//新闻信息
	self.Information = function(Parent, News, arr, page) {
		$.ajax({
			type: "get",
			url: url + '/api.aspx',
			data: {
				action: 'GetNewsList',
				ParentCode: Parent,
				NewsCode: News,
				page: page,
			},
			dataType: "JSON",
			success: function(msg) {
				arr.removeAll();
				for(var i = 0; i < msg.data.length; i++) {
					arr.push(msg.data[i]);
				}
				if(msg.pageCount > 1) {
					self.pagination(page, msg.pageCount)
				}
			}
		});
	};
	//分页
	self.pagination = function(page, pageCount) {
		self.pageList.removeAll();
		for(var i = 0; i < pageCount; i++) {
			self.pageList.push({
				page: (i + 1),
				currentPage: page + 1,
				url: '#',
			});
		}
	};
	self.pageClick = function(row) {
		self.GetCarxuanchuan(row.page - 1);
		var len = $('#page .Page a').length;
		if(row.page > 1) {
			$('#page .pageTurn').eq(0).show();
		} else {
			$('#page .pageTurn').eq(0).hide();
		}
		if(row.page == len) {
			$('#page .pageTurn').eq(1).hide();
		} else {
			$('#page .pageTurn').eq(1).show();
		}
	}

	self.firstPage = function() {
		self.GetCarxuanchuan(0);
		$('#page .pageTurn').eq(0).hide();
		$('#page .pageTurn').eq(1).show();
	}
	self.prevPage = function() {
		var len = $('#page .Page a').length;
		for(var i = 0; i < len; i++) {
			if($('#page .Page a').eq(i).hasClass('active')) {
				self.GetCarxuanchuan(i - 1);
				if(i == 1) {
					$('#page .pageTurn').eq(1).show();
					$('#page .pageTurn').eq(0).hide();
					return;
				} else {
					$('#page .pageTurn').eq(1).show();
					$('#page .pageTurn').eq(0).show();
				}
			}
		}
	}
	self.nextPage = function(row) {
		var len = $('#page .Page a').length;
		for(var i = 0; i < len; i++) {
			if($('#page .Page a').eq(i).hasClass('active')) {
				self.GetCarxuanchuan(i + 1);
				if(i == len - 2) {
					$('#page .pageTurn').eq(0).show();
					$('#page .pageTurn').eq(1).hide();
					return;
				} else {
					$('#page .pageTurn').eq(1).show();
					$('#page .pageTurn').eq(0).show();
				}
			}
		}
	}
	self.lastPage = function() {
		var len = $('#page .Page a').length - 1;
		self.GetCarxuanchuan(len);
		$('#page .pageTurn').eq(0).show();
		$('#page .pageTurn').eq(1).hide();
	}
}