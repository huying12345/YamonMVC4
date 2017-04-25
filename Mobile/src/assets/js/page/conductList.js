		function date(date) {
			var reg = /[0-9]+/g;
			var d = date.match(reg);
			var oldTime = new Date(d);
			var newTime = new Date(oldTime);
			return newTime;
		}

		function getMyDate(str) {
			var reg = /[0-9]+/g;
			var str1 = Number(str.match(reg));
			var oDate = new Date(str1),
				oYear = oDate.getFullYear(),
				oMonth = oDate.getMonth() + 1,
				oDay = oDate.getDate(),
				oHour = oDate.getHours(),
				oMin = oDate.getMinutes(),
				oSen = oDate.getSeconds(),
				oTime = oYear + '年' + getzf(oMonth) + '月' + getzf(oDay) + '日' + getzf(oHour) + ':' + getzf(oMin) + ':' + getzf(oSen); //最后拼接时间  
			return oTime;
		};
		//补0操作  
		function getzf(num) {
			if(parseInt(num) < 10) {
				num = '0' + num;
			}
			return num;
		}

		var essayViewmodel = function() {
			var self = this;
			var url = 'http://www.shlycmuseum.com';

			self.ListArry = ko.observableArray([]);
			self.Data = ko.observable();
			self.listLink = ko.observableArray([]);

			self.init = function() {
				self.essayFun();
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

			self.essayFun = function() {
				$.ajax({
					type: "get",
					url: url + '/api.aspx',
					data: {
						action: 'GetNews',
						id: $.getUrlVar('ID')
					},
					dataType: 'JSON',
					success: function(msg) {
						self.ListArry.push(msg.data);
						return msg.data.postTime;
					}
				});
			}
		}

		//		$.extend({
		//			getUrlVars: function() {
		//				var vars = [],
		//					hash;
		//				var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
		//				for(var i = 0; i < hashes.length; i++) {
		//					hash = hashes[i].split('=');
		//					vars.push(hash[0]);
		//					vars[hash[0]] = hash[1];
		//				}
		//				return vars;
		//			},
		//			getUrlVar: function(name) {
		//				return $.getUrlVars()[name];
		//			}
		//		});