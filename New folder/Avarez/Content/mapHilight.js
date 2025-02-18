(function (G) {
    var B, J, C, K, N, M, I, E, H, A, L;
    J = !!document.createElement("canvas").getContext;
    B = (function () {
        var P = document.createElement("div");
        P.innerHTML = '<v:shape id="vml_flag1" adj="1" />';
        var O = P.firstChild; O.style.behavior = "url(#default#VML)";
        return O ? typeof O.adj == "object" : true
    })();
    if (!(J || B)) {
        G.fn.maphilight = function () { return this };
        return
    } if (J) {
        E = function (O) { return Math.max(0, Math.min(parseInt(O, 16), 255)) };
        H = function (O, P) {
            return "rgba(" + E(O.substr(0, 2)) + "," + E(O.substr(2, 2))
         + "," + E(O.substr(4, 2)) + "," + P + ")"
        };
        C = function (O) {
            var P = G('<canvas style="width:' + O.width + "px;height:" + O.height + 'px;"></canvas>').get(0);
            P.getContext("2d").clearRect(0, 0, P.width, P.height); return P
        };
        var F = function (Q, O, R, P, S) {
            P = P || 0;
            S = S || 0;
            Q.beginPath();
            if (O == "rect") { Q.rect(R[0] + P, R[1] + S, R[2] - R[0], R[3] - R[1]) }
            else {
                if (O == "poly") {
                    Q.moveTo(R[0] + P, R[1] + S);
                    for (i = 2; i < R.length; i += 2) { Q.lineTo(R[i] + P, R[i + 1] + S) }
                }
                else {
                    if (O == "circ") { Q.arc(R[0] + P, R[1] + S, R[2], 0, Math.PI * 2, false) }
                }
            } Q.closePath()
        }; K = function (Q, T, U, X, O) {
            var S, P = Q.getContext("2d");
            if (X.shadow) {
                P.save();
                if (X.shadowPosition == "inside") {
                    F(P, T, U);
                    P.clip()
                } var R = Q.width * 100; var W = Q.height * 100;
                F(P, T, U, R, W); P.shadowOffsetX = X.shadowX - R;

                P.shadowOffsetY = X.shadowY - W; P.shadowBlur = X.shadowRadius;
                P.shadowColor = H(X.shadowColor, X.shadowOpacity);
                var V = X.shadowFrom;
                if (!V) {
                    if (X.shadowPosition == "outside")
                    { V = "fill" } else { V = "stroke" }
                } if
                  (V == "stroke") {
                    P.strokeStyle = "#cccccc";
                    P.stroke()
                } else {
                    if (V == "fill") {
                        P.fillStyle = "#ffbd00";
                        P.fill()
                    }
                } P.restore(); if (X.shadowPosition == "outside") {
                    P.save();
                    F(P, T, U); P.globalCompositeOperation = "destination-out";
                    P.fillStyle = "#ffbd00;";
                    P.fill(); P.restore()
                }
            } P.save();
            F(P, T, U);
            if (X.fill) {
                P.fillStyle = H(X.fillColor, X.fillOpacity);
                P.fill()
            } if (X.stroke) {
                P.strokeStyle = H(X.strokeColor, X.strokeOpacity);
                P.lineWidth = X.strokeWidth; P.stroke()
            } P.restore();
            if (X.fade) { G(Q).css("opacity", 0).animate({ opacity: 1 }, 100) }
        };
        N = function (O) { O.getContext("2d").clearRect(0, 0, O.width, O.height) }
    }
    else {
        C = function (O) {
            return G('<var style="zoom:1;overflow:hidden;display:block;width:' + O.width + "px;height:" + O.height + 'px;"></var>').get(0)
        };
        K = function (P, T, U, X, O) {
            var V, W, R, S; for (var Q in U) { U[Q] = parseInt(U[Q], 10) } V = '<v:fill color="##ffbd00" opacity="' + (X.fill ? X.fillOpacity : 0) + '" />';
            W = (X.stroke ? 'strokeweight="' + X.strokeWidth + '" stroked="t" strokecolor="#' + X.strokeColor + '"' : 'stroked="f"'); R = '<v:stroke opacity="' + X.strokeOpacity + '"/>';
            if (T == "rect") { S = G('<v:rect name="' + O + '" filled="t" ' + W + ' style="zoom:1;margin:0;padding:0;display:block;position:absolute;left:' + U[0] + "px;top:" + U[1] + "px;width:" + (U[2] - U[0]) + "px;height:" + (U[3] - U[1]) + 'px;"></v:rect>') }
            else {
                if (T == "poly") { S = G('<v:shape name="' + O + '" filled="t" ' + W + ' coordorigin="0,0" coordsize="' + P.width + "," + P.height + '" path="m ' + U[0] + "," + U[1] + " l " + U.join(",") + ' x e" style="zoom:1;margin:0;padding:0;display:block;position:absolute;top:0px;left:0px;width:' + P.width + "px;height:" + P.height + 'px;"></v:shape>') }
                else { if (T == "circ") { S = G('<v:oval name="' + O + '" filled="t" ' + W + ' style="zoom:1;margin:0;padding:0;display:block;position:absolute;left:' + (U[0] - U[2]) + "px;top:" + (U[1] - U[2]) + "px;width:" + (U[2] * 2) + "px;height:" + (U[2] * 2) + 'px;"></v:oval>') } }
            } S.get(0).innerHTML = V + R; G(P).append(S)
        }; N = function (P) { var O = G("<div>" + P.innerHTML + "</div>"); O.children("[name=highlighted]").remove(); P.innerHTML = O.html() }
    } M = function (P) {
        var O, Q = P.getAttribute("coords").split(",");
        for (O = 0; O < Q.length; O++) { Q[O] = parseFloat(Q[O]) }
        return [P.getAttribute("shape").toLowerCase().substr(0, 4), Q]
    };
    L = function (Q, P) {
        var O = G(Q);
        return G.extend({}, P, G.metadata ? O.metadata() : false, O.data("maphilight"))
    };
    A = function (O) {
        if (!O.complete) { return false } if (
    typeof O.naturalWidth != "undefined" && O.naturalWidth === 0) { return false }
        return true
    };
    I = { position: "absolute", left: 0, top: 0, padding: 0, border: 0 };
    var D = false; G.fn.maphilight = function (O) {
        O = G.extend({}, G.fn.maphilight.defaults, O); if (!J && !D) {
            G(window).ready(function () {
                document.namespaces.add("v", "urn:schemas-microsoft-com:vml");
                var Q = document.createStyleSheet(); var P = ["shape",
                 "rect", "oval", "circ", "fill", "stroke", "imagedata", "group", "textbox"];
                G.each(P, function () {
                    Q.addRule("v\\:" + this,
                 "behavior: url(#default#VML); antialias:true")
                })
            }); D = true
        } return this.each(function () {
            var U, R, Y, Q, T, V, X, S, W; U = G(this);
            if (!A(this)) {
                return window.setTimeout(function ()
                { U.maphilight(O) }, 200)
            } Y = G.extend({}, O, G.metadata ? U.metadata() : false,
            U.data("maphilight")); W = U.get(0).getAttribute("usemap");
            if (!W) { return } Q = G('map[name="' + W.substr(1) + '"]');
            if (!(U.is('img,input[type="image"]') && W && Q.size() > 0))
            { return } if (U.hasClass("maphilighted")) {
                var P = U.parent(); U.insertBefore(P); P.remove();
                G(Q).unbind(".maphilight").find("area[coords]").unbind(".maphilight")
            } R = G("<div></div>").css({ display: "block",
                background: 'url("' + this.src + '")', position: "relative",
                padding: 0, width: this.width, height: this.height
            });
            if (Y.wrapClass) {
                if (Y.wrapClass === true) {
                    R.addClass(G(this).attr("class"))
                } else { R.addClass(Y.wrapClass) }
            } U.before(R).css("opacity", 0).css(I).remove();
            if (B) { U.css("filter", "Alpha(opacity=0)") } R.append(U);
            T = C(this); G(T).css(I); T.height = this.height;
            T.width = this.width; X = function (c) {
                var a, b; b = L(this, Y);
                if (!b.neverOn && !b.alwaysOn) {
                    a = M(this); K(T, a[0], a[1], b, "highlighted");
                    if (b.groupBy) {
                        var Z; if (/^[a-zA-Z][\-a-zA-Z]+$/.test(b.groupBy))
                        { Z = Q.find("area[" + b.groupBy + '="' + G(this).attr(b.groupBy) + '"]') }
                        else { Z = Q.find(b.groupBy) } var d = this; Z.each(function () {
                            if (this != d) {
                                var f = L(this, Y); if (!f.neverOn && !f.alwaysOn)
                                { var e = M(this); K(T, e[0], e[1], f, "highlighted") }
                            }
                        })
                    }
                    if (!J) { G(T).append("<v:rect></v:rect>") }
                }
            };
            G(Q).bind("alwaysOn.maphilight", function () {
                if (V) { N(V) } if (!J) {
                    G(T).empty()
                } G(Q).find("area[coords]").each(function () {
                    var Z, a; a = L(this, Y); if (a.alwaysOn) {
                        if (!V && J) {
                            V = C(U[0]); G(V).css(I); V.width = U[0].width; V.height = U[0].height;
                            U.before(V)
                        } a.fade = a.alwaysOnFade; Z = M(this);
                        if (J) { K(V, Z[0], Z[1], a, "") } else { K(T, Z[0], Z[1], a, "") }
                    }
                })
            });
            G(Q).trigger("alwaysOn.maphilight").find("area[coords]").bind("mouseover.maphilight", X).bind("mouseout.maphilight", function (Z) {
                N(T)
            }); U.before(T); U.addClass("maphilighted")
        })
    };
    G.fn.maphilight.defaults = {
        fill: true, fillColor: "ffbd00", fillOpacity: 1,
        stroke: true, strokeColor: "cccccc", strokeOpacity: 1,
        strokeWidth: 1, fade: true, alwaysOn: false, neverOn: false,
        groupBy: false, wrapClass: true, shadow: false, shadowX: 0,
        shadowY: 0, shadowRadius: 6, shadowColor: "000000",
        shadowOpacity: 0.8, shadowPosition: "outside", shadowFrom: false
    }
})(jQuery);