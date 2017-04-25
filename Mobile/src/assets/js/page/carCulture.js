var carCulViewModel = function() {
	var self = this;
	var url = 'http://www.shlycmuseum.com';

	self.listcarculture = ko.observableArray([]);
	self.listcarculture3 = ko.observableArray([]);
	self.pageList = ko.observableArray([]);
	self.listLink = ko.observableArray([]);
	self.linkShop = ko.observableArray([]);

	self.init = function() {
			self.GetCarList(0);
			self.GetCarzixun();
			self.linkList();
			self.shopLink();
		}
		//汽车历史
	self.GetCarList = function(page) {
			self.Information(1842773441, 1540337913, self.listcarculture, page);
		}
		//汽车资讯
	self.GetCarzixun = function() {
			self.Information(1842773441, 1179322040, self.listcarculture3);
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
		//新闻信息
	self.Information = function(Parent, News, arr, page) {
		$.ajax({
			type: "get",
			url: url + '/api.aspx',
			data: {
				action: 'GetNewsList',
				ParentCode: Parent,
				NewsCode: News,
				page: page
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
	}

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
		self.GetCarList(row.page - 1);
		var len = $('#culture .Page a').length;

		if(row.page > 1) {
			$('#culture .pageTurn').eq(0).show();
		} else {
			$('#culture .pageTurn').eq(0).hide();
		}
		if(row.page == len) {
			$('#culture .pageTurn').eq(1).hide();
		} else {
			$('#culture .pageTurn').eq(1).show();
		}
	}
	self.firstPage = function() {
		self.GetCarList(0);
		$('#culture .pageTurn').eq(0).hide();
		$('#culture .pageTurn').eq(1).show();
	}
	self.prevPage = function() {
		var len = $('#culture .Page a').length;
		for(var i = 0; i < len; i++) {
			if($('#culture .Page a').eq(i).hasClass('active')) {
				self.GetCarList(i - 1);
				if(i == 1) {
					$('#culture .pageTurn').eq(1).show();
					$('#culture .pageTurn').eq(0).hide();
					return;
				} else {
					$('#culture .pageTurn').eq(1).show();
					$('#culture .pageTurn').eq(0).show();
				}
			}
		}
	}
	self.nextPage = function() {
		var len = $('#culture .Page a').length;

		for(var i = 0; i < len; i++) {
			if($('#culture .Page a').eq(i).hasClass('active')) {
				self.GetCarList(i + 1);
				if(i == len - 2) {
					$('#culture .pageTurn').eq(0).show();
					$('#culture .pageTurn').eq(1).hide();
					return;
				} else {
					$('#culture .pageTurn').eq(1).show();
					$('#culture .pageTurn').eq(0).show();
				}
			}
		}
	}
	self.lastPage = function() {
		var len = $('#culture .Page a').length - 1;
		self.GetCarList(len);
		$('#culture .pageTurn').eq(0).show();
		$('#culture .pageTurn').eq(1).hide();
	}
}