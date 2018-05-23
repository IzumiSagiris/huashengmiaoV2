$(function () {
	
	jQuery.support.placeholder = false;
	test = document.createElement('input');
	if('placeholder' in test) jQuery.support.placeholder = true;
	
	if (!$.support.placeholder) {
		
		$('.field').find ('label').show ();
		
    }

    $("#SignIn").click(function () {

        var username = document.getElementById('username');
        var password = document.getElementById('password');

        if (remember.checked) {
            setCookie('username', username.value, 7);
            setCookie('password', password.value, 7);
        }
        var data = { "username": username.value, "password": password.value }

        $.ajax({
            type: "POST",
            data: data,
            url: "/Sign/SignOn",
            success: function (result) {
                if (result.StatusCode == 200) {
                    location.href = result.StatusDescription;
                } else {
                    alert(result.StatusDescription);
                }
            }
        });

    })

    window.onload = function () {
        var oUser = document.getElementById('username');
        var oPswd = document.getElementById('password');
        var oRemember = document.getElementById('remember');
        //ҳ���ʼ��ʱ������ʺ�����cookie���������
        if (getCookie('username') && getCookie('password')) {
            oUser.value = getCookie('username');
            oPswd.value = getCookie('password');
            oRemember.checked = true;
        }
        //��ѡ��ѡ״̬�����ı�ʱ�����δ��ѡ�����cookie
        oRemember.onchange = function () {
            if (!this.checked) {
                delCookie('username');
                delCookie('password');
            }
        };

       
      
    };
    //����cookie
    function setCookie(name, value, day) {
        var date = new Date();
        date.setDate(date.getDate() + day);
        document.cookie = name + '=' + value + ';expires=' + date;
    };
    //��ȡcookie
    function getCookie(name) {
        var reg = RegExp(name + '=([^;]+)');
        var arr = document.cookie.match(reg);
        if (arr) {
            return arr[1];
        } else {
            return '';
        }
    };
    //ɾ��cookie
    function delCookie(name) {
        setCookie(name, null, -1);
    };

	
});