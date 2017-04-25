	var registerViewModel = function() {
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
		self.submit = function() {
			YamonAPI.POST('/api/Member/MemberInfo/Register', {
				MobileNo: $('#Phone').val(),
				MemberPassword: $('#password').val(),
				validate: $('#validate').val(),
				codeid: codeid
			}, function(result) {
				if(result.success) {
					$.toast('注册成功');
					 setTimeout(function(){
					 	location.href='order.html';
					 },2000)
				} else {
					$.toast.prototype.defaults.duration = '2000';
					$.toast(result.message, 'cancel');
					self.img();
				}
			});
		};
	}
	$('#Phone').on('change', function() {
		var reg = /^(0|86|17951)?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/;
		var phoneNum = $('#Phone').val();
		if(phoneNum != '') {
			if(reg.test(phoneNum) == false) {
				$.toast.prototype.defaults.duration = '2000';
				$.toast('手机号码格式不正确','cancel');
			}
		} else {
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
		} else {
			if(l < 6 || l > 18) {
				$.toast.prototype.defaults.duration = '2000';
				$.toast('请输入6到18位字符','cancel')
			}
		}
	});
	$('#validate').on('change', function() {
		var validate = $('#validate').val();
		if(validate == '') {
			$.toast.prototype.defaults.duration = '2000';
			$.toast('验证码不能为空','cancel')
		}
	});
	$('input:checkbox').click(function() {
		if($("input[type='checkbox']").is(':checked') == true) {
			$('#btn_submit').removeAttr('disabled')

		} else {
			$('#btn_submit').attr('disabled', 'disabled')
		}
	});