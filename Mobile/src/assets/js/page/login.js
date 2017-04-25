	var loginViewModel = function() {
		var self = this;
		var codeid = '';
		var url = 'http://www.shlycmuseum.com';
		
		self.listLink = ko.observableArray([]);
		
		self.init = function() {
			self.img();
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
		
		self.img = function() {
			YamonAPI.POST('/api/SiteManage/ValidateCode/GetValidateCode', function(result) {
				if(result.success) {
					$("#changeImg").attr("src", 'data:image/jpg;base64,' + result.image);
					codeid = result.codeid;
				} else {
					$.toast.prototype.defaults.duration = '2000';
					$.toast(result.message,'cancel');
					self.img();
				}
			})
		};
		self.login = function() {
			YamonAPI.POST('/api/Member/MemberInfo/MemberLogin', {
				phone: $('#Phone').val(),
				password: $('#password').val(),
				validate: $('#validate').val(),
				codeid: codeid
			}, function(result) {
				if(result.success) {
					$.cookie('__token', result.token);
					$.cookie('__isMemberLogin', 1);
					$.cookie('__phone', $('#Phone').val());
					window.location.href = "order.html"
				} else {
					$.toast.prototype.defaults.duration = '2000';
					$.toast(result.message,'cancel');
					self.img();
				}
			});
		};
	};
	$(function() {
		$('#Phone').on('change', function() {
			var phoneNum = $('#Phone').val();
			if(phoneNum = '') {
				$.toast.prototype.defaults.duration = '2000';
				$.toast('手机号不能为空','cancel');
			}
		});
		$('#password').on('change', function() {
			var pwd = $('#password').val();
			var l = pwd.length;
			if(pwd == '') {
				$.toast.prototype.defaults.duration = '2000';
				$.toast('密码不能为空','cancel')
			}
		});
		$('#validate').on('change', function() {
			var validate = $('#validate').val();
			if(validate == '') {
				$.toast.prototype.defaults.duration = '2000';
				$.toast('验证码不能为空','cancel')
			}
		});
	})