var carListViewModel = function() {
	var self = this;
	var url = 'http://www.shlycmuseum.com';

	self.listCars = ko.observableArray([]);
	self.listCarName = ko.observableArray([]);
	self.listCarYear = ko.observableArray([]);
	self.listCarArea = ko.observableArray([]);
	self.listLink = ko.observableArray([]);
	self.linkShop = ko.observableArray([]);

	self.init = function() {
			self.CarsList();
			self.GetName();
			self.GetYear();
			self.GetArea();
			self.linkList();
			self.shopLink();
		}
		//汽车名字
	self.GetName = function() {
			self.Data(self.listCarName, 0);
		}
		//地区
	self.GetArea = function() {
			self.Data(self.listCarArea, 1);
		}
		//汽车年份
	self.GetYear = function() {
		self.Data(self.listCarYear, 2);
	}

	self.carSearch = function() {
		self.CarsList();
	}

	//汽车车型
	self.CarsList = function() {
		$.ajax({
			type: "get",
			url: url + "/api.aspx",
			data: {
				action: 'GetCarList',
				brandClassId: $('#brand').val(),
				yearClassId: $('#year').val(),
				countriesClassId: $('#city').val(),
				carsName: $('#carsName').val()
			},
			dataType: "JSON",
			success: function(msg) {
				self.listCars.removeAll();
				for(var i = 0; i < msg.data.length; i++) {
					self.listCars.push(msg.data[i]);
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
		//汽车信息
	self.Data = function(rows, classId) {
		$.ajax({
			type: "get",
			url: url + "/api.aspx",
			data: {
				action: 'GetTagList',
				ClassId: classId,
			},
			dataType: 'JSON',
			success: function(msg) {
				for(var i = 0; i < msg.data.length; i++) {
					rows.push(msg.data[i]);
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
}
$(function() {
	$('.backtup').hide();
	$('.header').show();
	var onoff = false;
	$('.searchbar').on('click', function() {
		if(onoff == false) {
			$(this).parent().animate({
				'right': '0px'
			}, 500);
		} else {
			$(this).parent().animate({
				'right': '-267px'
			}, 500);
		}
		onoff = !onoff;
	});
	$('#cars #submit').click(function() {
		$('.searchbar').parent().animate({
			'right': '-267px'
		}, 500);
		$('#cars #keywords').val('');
	})
});