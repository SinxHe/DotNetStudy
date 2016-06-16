//自执行函数: 1. 创建完立即执行 2. 别人不能访问
// extend(target, src) 函数: src覆盖target中相同的字段, 不同的直接加进去
(function ($) {
    $.extend($, {
        ProcessAjaxData: function(data, funcOk, funcErr) {
            if (!data.Statu) {
                return;
            }

            switch (data.Statu) {
                case "Ok":
                    alert("Ok: " + data.Msg);
                    if (funcOk) funcOk(data);
                    break;
                case "Err":
                    alert("Err: " + data.Msg);
                    if (funcErr) funcErr(data);
                    break;
                case "NoLogin":
                    alert("NoLogin: " + data.Msg);
                    window.location = data.BackUrl;
                    break;
                default:
                    alert("异常: 位置的AjaxData状态!");
                    break;
            }
        }
    });
}(jQuery));