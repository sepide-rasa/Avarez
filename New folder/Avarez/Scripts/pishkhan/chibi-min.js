/*!chibi 3.0.9, Copyright 2012-2017 Kyle Barrow, released under MIT license */
!function () {
    "use strict"; function e() {
        var e; for (h = !0, e = 0; e < d.length; e += 1) d[e](); d = []
    } function t() {
        var t; for (y = !0, h || e(), t = 0; t < p.length; t += 1) p[t](); p = []
    } function n(e, t) {
        var n; for (n = t.length - 1; n >= 0; n -= 1) e(t[n])
    } function r(e) {
        return e.replace(/-\w/g, function (e) {
            return e.charAt(1).toUpperCase()
        })
    } function a(e, t) {
        return e.currentStyle ? e.currentStyle[r(t)] : v.getComputedStyle ? v.getComputedStyle(e, null).getPropertyValue(t) : null
    } function o(e, t) {
        return encodeURIComponent(e).replace(/%20/g, "+") + "=" + encodeURIComponent(t).replace(/%20/g, "+")
    } function c(e, t, n) {
        try { e.style[r(t)] = n } catch (e) { console.error('Could not set css style property "' + t + '".') }
    } function s(e) {
        e.style.display = "", "none" === a(e, "display") && (e.style.display = "block")
    } function i(e) {
        var t, r, a, c = ""; if (e.constructor === Object) {
            for (t in e) if (e.hasOwnProperty(t))
                if (e[t].constructor === Array)
                    for (r = 0; r < e[t].length; r += 1) c += "&" + o(t, e[t][r]);
                else c += "&" + o(t, e[t])
        } else n(function (e) {
            if ("FORM" === e.nodeName)
                for (r = 0; r < e.elements.length; r += 1)
                    if (!(t = e.elements[r]).disabled)
                        switch (t.type) {
                            case "button": case "image":
                            case "file":
                            case "submit":
                            case "reset":
                                break;
                            case "select-one":
                                t.length > 0 && (c += "&" + o(t.name, t.value));
                                break;
                            case "select-multiple":
                                for (a = 0; a < t.length; a += 1)
                                    t[a].selected && (c += "&" + o(t.name, t[a].value));
                                break;
                            case "checkbox":
                            case "radio": t.checked && (c += "&" + o(t.name, t.value));
                                break;
                            default: c += "&" + o(t.name, t.value)
                        }
        }, e); return c.length > 0 ? c.substring(1) : ""
    } function u(e, t, r) {
        var a, o, c, s, i = !1;
        return e && (a = e.split(/\s+/), n(function (e) {
            for (s = 0; s < a.length; s += 1)
                if (o = new RegExp("\\b" + a[s] + "\\b", "g"), c = new RegExp(" *" + a[s] + "\\b", "g"), "remove" === t)
                    e.className = e.className.replace(c, "");
                else if ("toggle" === t)
                    e.className = e.className.match(o) ? e.className.replace(c, "") : e.className + " " + a[s];
                else if ("has" === t && e.className.match(o)) {
                    i = !0;
                    break
                }
        }, r)
            ), i
    } function l(e, t, r) {
        var a, o; e && n(function (n) {
            for ((a = g.createElement("div")).innerHTML = e;
                null !== (o = a.lastChild) ;)
                try {
                    "before" === t ? n.parentNode.insertBefore(o, n) : "after" === t ? n.parentNode.insertBefore(o, n.nextSibling) : "append" === t ? n.appendChild(o) : "prepend" === t && n.insertBefore(o, n.firstChild)
                } catch (e) {
                    break
                }
        }, r)
    } function f(e) {
        var t, o, E, T = [], b = !1;
        if (e)
            if (e.nodeType && 1 === e.nodeType) T = [e];
            else if ("object" == typeof e) b = "number" != typeof e.length, T = e;
            else if ("string" == typeof e)
                for (g.querySelectorAll || (g.querySelectorAll = function (e) {
                var t, n, r, o = g.getElementsByTagName("head")[0], c = [];
                if (t = g.createElement("STYLE"), t.type = "text/css", t.styleSheet) {
                for (t.styleSheet.cssText = e + " {a:b}", o.appendChild(t), n = g.getElementsByTagName("*"),
                r = 0; r < n.length; r += 1) "b" === a(n[r], "a") && c.push(n[r]); o.removeChild(t)
                } return c
                }), o = g.querySelectorAll(e), E = 0; E < o.length; E += 1) T[E] = o[E];
        return t = b ? {} : T, t.ready = function (e) {
            if (e) { if (h) return e(), t; d.push(e) }
        }, t.loaded = function (e) {
            if (e) { if (y) return e(), t; p.push(e) }
        }, t.each = function (e) {
            return "function" == typeof e && n(function (t) {
                return e.apply(t, arguments)
            }, T), t
        }, t.first = function () {
            return f(T.shift())
        }, t.last = function () {
            return f(T.pop())
        }, t.odd = function () {
            var e, t = [];
            for (e = 0; e < T.length; e += 2)
                t.push(T[e]);
            return f(t)
        }, t.even = function () {
            var e, t = [];
            for (e = 1; e < T.length; e += 2)
                t.push(T[e]);
            return f(t)
        }, t.hide = function () {
            return n(function (e) { e.style.display = "none" }, T), t
        }, t.show = function () {
            return n(function (e) { s(e) }, T), t
        }, t.toggle = function () {
            return n(function (e) {
                "none" === a(e, "display") ? s(e) : e.style.display = "none"
            }, T), t
        }, t.remove = function () {
            return n(function (e) {
                try {
                    e.parentNode.removeChild(e)
                } catch (e) { }
            }, T), f()
        }, t.css = function (e, o) {
            if (e) {
                if (o || "" === o) return n(function (t) {
                    c(t, e, o)
                }, T), t; if (T[0]) {
                    if (T[0].style[r(e)])
                        return T[0].style[r(e)]; if (a(T[0], e)) return a(T[0], e)
                }
            }
        }, t.getClass = function () {
            if (T[0] && T[0].className.length > 0)
                return T[0].className.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, "").replace(/\s+/, " ")
        }, t.setClass = function (e) {
            return (e || "" === e) && n(function (t) { t.className = e }, T), t
        }, t.addClass = function (e) {
            return e && n(function (t) { t.className += " " + e }, T), t
        }, t.removeClass = function (e) {
            return u(e, "remove", T), t
        }, t.toggleClass = function (e) {
            return u(e, "toggle", T), t
        }, t.hasClass = function (e) { return u(e, "has", T) }, t.html = function (e) {
            return e || "" === e ? (n(function (t) { t.innerHTML = e }, T), t) : T[0] ? T[0].innerHTML : void 0
        }, t.htmlBefore = function (e) { return l(e, "before", T), t }, t.htmlAfter = function (e) {
            return l(e, "after", T), t
        }, t.htmlAppend = function (e) { return l(e, "append", T), t }, t.htmlPrepend = function (e) {
            return l(e, "prepend", T), t
        }, t.attr = function (e, r) {
            if (e) {
                if (e = e.toLowerCase(), r || "" === r) return n(function (t) {
                    "style" === e ? t.style.cssText = r : "class" === e ? t.className = r : t.setAttribute(e, r)
                }, T), t; if (T[0]) if ("style" === e) { if (T[0].style.cssText) return T[0].style.cssText }
                else if ("class" === e) { if (T[0].className) return T[0].className }
                else if (T[0].getAttribute(e)) return T[0].getAttribute(e)
            }
        }, t.data = function (e, n) {
            if (e)
                return t.attr("data-" + e, n)
        }, t.val = function (e) {
            var r, a, o; if (e || "" === e)
                return n(function (t) {
                    switch (t.nodeName) {
                        case "SELECT": for ("string" != typeof e && "number" != typeof e || (e = [e]), a = 0; a < t.length; a += 1)
                            for (o = 0; o < e.length; o += 1) if (t[a].selected = "", t[a].value === e[o]) {
                                t[a].selected = "selected";
                                break
                            } break; case "INPUT": case "TEXTAREA": case "BUTTON": t.value = e
                    }
                }, T), t; if (T[0])
                    switch (T[0].nodeName) {
                        case "SELECT":
                            for (r = [], a = 0; a < T[0].length; a += 1)
                                T[0][a].selected && r.push(T[0][a].value);
                            return r.length > 1 ? r : r[0];
                        case "INPUT":
                        case "TEXTAREA":
                        case "BUTTON":
                            return T[0].value
                    }
        }, t.checked = function (e) {
            return "boolean" == typeof e ? (n(function (t) {
                "INPUT" !== t.nodeName || "checkbox" !== t.type && "radio" !== t.type || (t.checked = e)
            }, T), t) : !T[0] || "INPUT" !== T[0].nodeName || "checkbox" !== T[0].type && "radio" !== T[0].type ? void 0 : !!T[0].checked
        }, t.on = function (r, a) {
            return e !== v && e !== g || (T = [e]), n(function (e) {
                g.addEventListener ? e.addEventListener(r, a, !1) : g.attachEvent && (e[r + a] = function () {
                    return a.apply(e, arguments)
                }, e.attachEvent("on" + r, e[r + a]))
            }, T), t
        }, t.off = function (r, a) {
            return e !== v && e !== g || (T = [e]), n(function (e) {
                g.addEventListener ? e.removeEventListener(r, a, !1) : g.attachEvent && (e.detachEvent("on" + r, e[r + a]), e[r + a] = null)
            }, T), t
        }, t.ajax = function (e, n, r, a, o) {
            var c, s, u = i(T), l = n ? n.toUpperCase() : "GET",
                f = new RegExp("http[s]?://(.*?)/", "gi").exec(e), d = "_ts=" + +new Date,
                p = g.getElementsByTagName("head")[0], h = "chibi" + +new Date + (m += 1);
            return !u || "GET" !== l && "DELETE" !== l || (e += -1 === e.indexOf("?") ? "?" + u : "&" + u, u = null),
                "GET" === l && !o && f && v.location.host !== f[1] ? (a && (e += -1 === e.indexOf("?") ? "?" + d : "&" + d),
                e = e.replace("=%3F", "=?"), r && -1 !== e.indexOf("=?") && (e = e.replace("=?", "=" + h),
                v[h] = function (e) {
                    try { r(e, 200) } catch (e) {
                    } v[h] = void 0
                }), (s = document.createElement("script")).async = !0, s.src = e, s.onload = function () {
                    p.removeChild(s)
                }, p.appendChild(s)) : (v.XMLHttpRequest ? c = new XMLHttpRequest : v.ActiveXObject && (c = new ActiveXObject("Microsoft.XMLHTTP")),
                c && (a && (e += -1 === e.indexOf("?") ? "?" + d : "&" + d), c.open(l, e, !0), c.onreadystatechange = function () {
                    4 === c.readyState && r && r(c.responseText, c.status)
                }, c.setRequestHeader("X-Requested-With", "XMLHttpRequest"),
                "POST" !== l && "PUT" !== l || c.setRequestHeader("Content-Type", "application/x-www-form-urlencoded"), c.send(u))), t
        }, t.get = function (e, n, r, a) {
            return t.ajax(e, "get", n, r, a)
        }, t.post = function (e, n, r) { return t.ajax(e, "post", n, r) }, t
    } var d = [], p = [], h = !1, y = !1, m = 0, g = document, v = window;
    g.addEventListener ? (g.addEventListener("DOMContentLoaded", e, !1),
    v.addEventListener("load", t, !1)) : g.attachEvent ? (g.attachEvent("onreadystatechange", e)
    , v.attachEvent("onload", t)) : v.onload = t, v.$ = f
}();