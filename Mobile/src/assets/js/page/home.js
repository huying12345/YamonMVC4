var homeImgViewModel = function() {
	var self = this;
	var url = 'http://www.shlycmuseum.com';

	self.homeImgList1 = ko.observableArray([]);
	self.homeImgList2 = ko.observableArray([]);
	self.homeImgList3 = ko.observableArray([]);
	self.homeImgList4 = ko.observableArray([]);
	self.listLink = ko.observableArray([]);
	self.linkShop = ko.observableArray([]);

	self.init = function() {
		self.getHomeImg();
		self.linkList();
		self.shopLink();
	}

	//首页图片
	self.getHomeImg = function() {
			$.ajax({
				type: "get",
				url: url + "/api.aspx",
				dataType: 'JSON',
				data: {
					action: 'GetAdList',
					ClassId: 1202836778
				},
				success: function(msg) {
					self.homeImgList1.removeAll();
					self.homeImgList2.removeAll();
					self.homeImgList3.removeAll();
					self.homeImgList4.removeAll();
					for(var i = 0; i < msg.data.length; i++) {
						self.homeImgList1.push(msg.data[0]);
						self.homeImgList2.push(msg.data[1]);
						self.homeImgList3.push(msg.data[2]);
						self.homeImgList4.push(msg.data[3]);
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
$(function() {
	$('#img').hide();
	$('.header').show();
	$('#dowebok').fullpage({
		scrollingSpeed: 400,
		'verticalCentered': false,
		'css3': true,
		anchors: ['page1', 'page2', 'page3', 'page4'],
		afterLoad: function(anchorLink, index) {
			if(index == 4) {
				$('.up_icon').hide();
				$('.Shop').show();
			} else {
				$('.up_icon').show();
				$('.Shop').hide();
			}
		}
	})
	$('.backUp').on('click', function() {
		$('#dowebok').fullpage.moveTo(1, 0);
		$('#dowebok2').fullpage.moveTo(1, 0);
	});
	$('#up_icon').on('click', function() {
		$('#dowebok').fullpage.moveSectionDown();
	});
	
});
