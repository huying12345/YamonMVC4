$(function() {
	//菜单栏
	$('.lanmu').on('click', function() {
		$('#foot').toggle();
	});
	//返回顶部
	$('.backUp').on('click', function() {
		$("html,body").animate({
			scrollTop: 0 + 'px'
		}, 500);
	});
	//二級菜单显示条件
	$('#carCulture').click(function() {
		$('#artList').toggle();
	})
	$('#aboutus').click(function() {
			$('#aboutsList').toggle();
		})
		//搜索弹框
	$('#search').on('click', function() {
			$.prompt({
				title: '搜索',
				input: '',
				empty: false, // 是否允许为空
				onOK: function(input) {
					location.href = './keyWords.html?keyword=' + input;
				},
				onCancel: function() {
					//点击取消
				}
			});
		})
		//退出登录
	$("#backl").click(function() {
		$.cookie('__token', null);
		$.cookie('__isMemberLogin', null);
		$.cookie('__phone', null);
		if($.cookie('__token') == 'null' || $.cookie('__token') == null) {
			window.location.href = YamonAPI.webUrl + "/login.html"
		}
	});
});
//swiper + 图片放大
//图片幻灯片（img标签加属性 name="pb1" class="pb1" ）（z-index: 0;）(swiper.js)
var imgs = new Array();
var captions = new Array();
var nowImgurl = "";
var index = 0;
window.onload = function() {
	setTimeout(function() {
		$.hideLoading();
		$('img[name="pb1"]').each(function(i) {
			imgs.push({
				image: $(this).attr('src'),
				caption: $(this).attr('content')
			});
		});
		var pb1 = $.photoBrowser({
			items: imgs,
			initIndex: 0,
			onSlideChange: function(index) {},
			onOpen: function(index) {

			},
			onClose: function() {
				$('#back').hide();
			}
		});
		$(".pb1").click(function() {
			pb1.open();
			$('.weui-photo-browser-modal .swiper-slide').each(function() {
				$(this).append("<a href='#' class='carBack' style='position:absolute;top:10px;left:10px;font-size:25px'><i class='iconfont icon-fanhui' style='color:#fff;'></i></a>");
			})
		});
		$('.carBack').click(function() {
			pb1.close();
		})
	}, 1000)
}

//获取网址传递的参数
function GetQueryString(name) {
	var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
	var r = window.location.search.substr(1).match(reg);
	if(r != null) return unescape(r[2]);
	return null;
}

function HTMLEncode(html) {
	var temp = document.createElement("div");
	(temp.textContent != null) ? (temp.textContent = html) : (temp.innerText = html);
	var output = temp.innerHTML;
	temp = null;
	return output;
}

function HTMLDecode(text) {
	var temp = document.createElement("div");
	temp.innerHTML = text;
	var output = temp.innerText || temp.textContent;
	temp = null;
	return output;
}
//文字限制
function show(cls) {
	var box = document.getElementsByClassName(cls);
	var text = box.innerHTML;
	//	alert(text);
	var newBox = document.createElement("span");
	var btn = document.createElement("a");
	newBox.innerHTML = text.substring(0, 100);
	btn.innerHTML = text.length > 100 ? "...显示全部" : "";
	btn.href = "###";

	btn.onclick = function() {
		if(btn.innerHTML == "...显示全部") {
			btn.innerHTML = "收起";
			newBox.innerHTML = text;
		} else {
			btn.innerHTML = "...显示全部";
			newBox.innerHTML = text.substring(0, 100);
		}
	}
	box.innerHTML = "";
	box.appendChild(newBox);
	box.appendChild(btn);
}

$.extend({
	getUrlVars: function() {
		var vars = [],
			hash;
		var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
		for(var i = 0; i < hashes.length; i++) {
			hash = hashes[i].split('=');
			vars.push(hash[0]);
			vars[hash[0]] = hash[1];
		}
		return vars;
	},
	getUrlVar: function(name) {
		return $.getUrlVars()[name];
	}
});