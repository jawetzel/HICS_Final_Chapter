//	banner js
if (typeof em5 === 'undefined') {
    var em5 = window.addEventListener ? "addEventListener" : "attachEvent";
    var er5 = window[em5];
    var me5 = em5 == "attachEvent" ? "onmessage" : "message";
    er5(me5, function(e) {
        var s5 = e.data;
        if (s5.substring(0, 10) == "changeSize") {
            document.getElementById(s5.substring(s5.indexOf("html5maker") + 10)).style.height = s5.substring(10, s5.indexOf("html5maker"));
        }
    }, false);
}