$(function () {
    var t, e, i, s, n, o, a = BAGE({
        imagePath: "/Areas/BcGame/SImages/"
    }).include("shapes, board, movie").setup("gameScene"),
        l = BAGE({
            imagePath: "/Areas/BcGame/SImages/"

        }).include("shapes, board, movie").setup("bgScene"),
        r = document.getElementById("gameGrid"),
        c = "http://www.w3.org/2000/svg",
        d = "/Areas/BcGame/mp3/Expl.mp3",
        h = "/Areas/BcGame/mp3/rocket.mp3",
        p = "/Areas/BcGame/mp3/Plane.mp3",
        u = "/Areas/BcGame/mp3/fail.mp3",
        g = 15,
        f = 15,
        x = 0,
        y = 1,
        b = 0,
        m = 0,
        w = !1,
        v = !1,
        k = null,
        g = 2,
        f = 15,
        S = !1,
        C = $("#lblLives"),
        I = $("#codeTExt"),
        B = $("#shoots"),
        T = [],
        N = function () {
            T = [{
                count: 1,
                startIndex: 0,
                endIndex: 0
            }, {
                count: 12,
                startIndex: 1,
                endIndex: 12
            }, {
                count: 15,
                startIndex: 13,
                endIndex: 27
            }, {
                count: 14,
                startIndex: 28,
                endIndex: 41
            }, {
                count: 14,
                startIndex: 42,
                endIndex: 55
            }, {
                count: 3,
                startIndex: 56,
                endIndex: 58
            }, {
                count: 17,
                startIndex: 59,
                endIndex: 75
            }, {
                count: 6,
                startIndex: 76,
                endIndex: 81
            }, {
                count: 36,
                startIndex: 82,
                endIndex: 117
            }, {
                count: 8,
                startIndex: 118,
                endIndex: 125
            }, {
                count: 15,
                startIndex: 126,
                endIndex: 140
            }, {
                count: 17,
                startIndex: 141,
                endIndex: 157
            }, {
                count: 9,
                startIndex: 158,
                endIndex: 166
            }, {
                count: 5,
                startIndex: 167,
                endIndex: 171
            }, {
                count: 4,
                startIndex: 172,
                endIndex: 175
            }, {
                count: 4,
                startIndex: 176,
                endIndex: 179
            }]
        },
        E = [],
        _ = function () {
            E = ["TASI", "TBFSI", "1010", "1020", "1030", "1040", "1050", "1060", "1080", "1090", "1120", "1140", "1150", "TPISI", "2001", "2002", "2010", "2020", "2060", "2170", "2210", "2250", "2260", "2290", "2310", "2330", "2350", "2380", "TCESI", "3001", "3002", "3003", "3004", "3010", "3020", "3030", "3040", "3050", "3060", "3080", "3090", "3091", "TRESI", "4001", "4002", "4003", "4004", "4005", "4006", "4050", "4160", "4180", "4190", "4200", "4240", "4290", "TEUSI", "2080", "5110", "TAFSI", "2050", "2100", "2270", "2280", "4061", "6001", "6002", "6004", "6010", "6020", "6040", "6050", "6060", "6070", "6080", "6090", "TTISI", "7010", "7020", "7030", "7040", "7050", "TINSI", "8010", "8011", "8012", "8020", "8030", "8040", "8050", "8060", "8070", "8080", "8090", "8100", "8110", "8120", "8130", "8140", "8150", "8160", "8170", "8180", "8190", "8200", "8210", "8220", "8230", "8240", "8250", "8260", "8270", "8280", "8290", "8300", "8310", "8311", "8312", "TMISI", "2030", "2120", "2140", "2190", "4080", "4130", "4280", "TIVSI", "1201", "1210", "1211", "1212", "1213", "1214", "2070", "2150", "2180", "2220", "2230", "2300", "2340", "4140", "TBCSI", "1301", "1302", "1310", "1320", "1330", "2040", "2090", "2110", "2130", "2160", "2200", "2240", "2320", "2360", "2370", "4230", "TRDSI", "4020", "4090", "4100", "4150", "4220", "4250", "4300", "4310", "TTRSI", "4030", "4040", "4110", "4260", "TMPSI", "4070", "4210", "4270", "THTSI", "1810", "4010", "4170"]
        },
        R = [],
        P = function () {
            R = ["المؤشر العام للسوق السعودي", "قطاع المصارف والخدمات المالية", "الرياض", "الجزيرة", "استثمار", "السعودي الهولندي", "السعودي الفرنسي", "ساب", "العربي الوطني", "سامبا", "الراجحي", "البلاد", "الإنماء", "قطاع الصناعات البتروكيماوية", "كيمانول", "بتروكيم", "سابك", "سافكو", "التصنيع", " اللجين", " نماء للكيماويات", " المجموعة السعودية", "الصحراء للبتروكيماويات", " ينساب", "سبكيم العالمية", "المتقدمة", " كيان السعودية", " بترو رابغ", "قطاع الاسمنت", "أسمنت حائل", "أسمنت نجران", "اسمنت المدينة", "اسمنت الشمالية", "الاسمنت العربية", "اسمنت اليمامة", "اسمنت السعوديه", "اسمنت القصيم", "اسمنت الجنوبيه", "اسمنت ينبع", "اسمنت الشرقية", "اسمنت تبوك", "اسمنت الجوف", "قطاع التجزئة", "أسواق العثيم", "المواساة", "إكسترا", "دله الصحية", "رعاية", "أسواق المزرعة", "خدمات السيارات", "ثمار", "فتيحي", "جرير", "الدريس", "الحكير", "الخليج للتدريب", "قطاع الطاقة والمرافق الخدمية", " الغاز والتصنيع", "كهرباء السعودية", "قطاع الزراعة والصناعات الغذائية", "مجموعة صافولا", "الغذائية", "سدافكو", "المراعي", "أنعام القابضة", "حلواني إخوان", "هرفي للأغذية", "التموين", "نادك", "القصيم الزراعيه", "تبوك الزراعيه", "الأسماك", "الشرقية الزراعيه", "الجوف الزراعيه", "بيشة الزراعيه", "جازان للتنمية", "قطاع الاتصالات وتقنية المعلومات", "الاتصالات", "اتحاد اتصالات", "زين السعودية", "عذيب للاتصالات", "المتكاملة", "قطاع التأمين", "التعاونية", "العربي للتأمين", "جزيرة تكافل", "ملاذ للتأمين", "ميدغلف للتأمين", "أليانز إس إف", "سلامة", "ولاء للتأمين", "الدرع العربي", "ساب تكافل", "سند", "سايكو", "وفا للتأمين", "اتحاد الخليج", "الأهلي للتكافل", "الأهلية", "أسيج", "التأمين العربية", "الاتحاد التجاري", "الصقر للتأمين", "المتحدة للتأمين", "إعادة", "بوبا العربية", "وقاية للتكافل", "الراجحي للتأمين", "ايس", "اكسا - التعاونية", "الخليجية العامة", "بروج للتأمين", "العالمية", "سوليدرتي تكافل", "الوطنية", "أمانة للتأمين", "عناية", "الإنماء طوكيوم", "قطاع شركات الأستثمار المتعدد", "المصافي", "المتطورة", "الاحساء للتنميه", "سيسكو", "عسير", "الباحة", "المملكة", "قطاع الأستثمار الصناعي", "تكوين", "بي سى آى", "معادن", "أسترا الصناعية", "مجموعة السريع", "شاكر", "الدوائية", "زجاج", "فيبكو", "معدنية", "الكيميائيه السعوديه", "صناعة الورق", "العبداللطيف", "الصادرات", "قطاع التشييد والبناء", "أسلاك", "بوان", "مجموعة المعجل", "الأنابيب السعودية", "الخضري", "الخزف", "الجبس", "الكابلات", "صدق", "اميانتيت", "أنابيب", "الزامل للصناعة", "البابطين", "الفخارية", "مسك", "البحر الأحمر", "قطاع التطوير العقاري", "العقارية", "طيبة للاستثمار", "مكة للانشاء", "التعمير", "إعمار", "جبل عمر", "دار الأركان", "مدينة المعرفة", "قطاع النقل", " البحري", " النقل الجماعي", "مبرد", "بدجت السعودية", "قطاع الاعلام والنشر", "تهامه للاعلان", "الأبحاث و التسويق", "طباعة وتغليف", "قطاع الفنادق والسياحة", "الطيار", "الفنادق", " شمس"]
        },
        L = [],
        M = function () {
            L.length = 0;
            var t = document.getElementById("option1"),
                e = document.forms[0].sector;
            if (1 == t.checked)
                for (var i = 0; i < e.length; i++) L.push(i);
            else
                for (var i = 0; i < e.length; i++) 1 == e[i].checked && L.push(i)
        },
        A = [],
        O = function () {
            g = 15, f = 15, x = 0, y = 1, b = 0, m = 0, w = !1, t = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], N(), _(), P(), M(), A.length = 0;
            for (var e = [], i = 0; i < L.length; i++)
                for (j = 0; j < T[L[i]].count; j++) e.push({
                    sectorIndex: i,
                    sector: L[i],
                    index: T[L[i]].startIndex + j,
                    code: E[T[L[i]].startIndex + j],
                    shoot: !1
                });
            for (var i = 0; e.length > 0;) {
                var s = Math.floor(Math.random() * e.length);
                A.push(e[s]), e.splice(s, 1)
            }
        },
        D = [],
        G = [],
        Y = function () {
            G.length = 0, G.push("t"), G.push("f"), G.push("t");
            for (var t = document.forms[0].sector, e = 1; e < t.length; e++) G.push("f")
        },
        z = function () {
            var t = document.getElementById("rdTr");
            G[0] = 1 == t.checked ? "t" : "f";
            var e = document.getElementById("option1");
            G[1] = 1 == e.checked ? "t" : "f";
            for (var i = document.forms[0].sector, s = 1; s < i.length; s++) G[s + 2] = 1 == i[s].checked ? "t" : "f"
        },
        W = function () {
            var t = document.forms[0].sector;
            if ("t" == G[0]) {
                $("#option1").attr("disabled", ""), $("#allSectorCell").removeClass("allSectorDisabled"), $("#listMenu").removeClass("ListContainerHidden"), $("#listMenu *:not(#tasi)").attr("disabled", ""), $("#rdTr").attr("checked", "checked"), "t" == G[1] ? $("#option1").attr("checked", "checked") : $("#option1").attr("checked", "");
                for (var e = 1; e < t.length; e++) t[e].checked = "t" == G[e + 2] ? !0 : !1
            } else $("#option1").attr("disabled", "disabled"), $("#allSectorCell").addClass("allSectorDisabled"), $("#listMenu").addClass("ListContainerHidden"), $("#listMenu *").attr("checked", "checked"), $("#listMenu *").attr("disabled", "disabled"), $("#rdCom").attr("checked", "checked"), $("#option1").attr("checked", "checked")
        },
        F = function (t) {
            var e = document.getElementById("soundPlayer");
            null !== e && (e.src = t, e.play())
        },
        H = function (t) {
            var e = document.getElementById("bgSoundPlayer");
            null !== e && (e.src = t, e.play())
        },
        X = function (t) {
            if (0 == t) {
                var e = document.getElementById("soundPlayer");
                null !== e && e.pause();
                var i = document.getElementById("bgSoundPlayer");
                null !== i && i.pause()
            } else if (1 == t) {
                var e = document.getElementById("soundPlayer");
                null !== e && e.pause()
            } else if (2 == t) {
                var i = document.getElementById("bgSoundPlayer");
                null !== i && i.pause()
            }
        },
        q = function (t) {
            if (0 == t) {
                var e = document.getElementById("bgSoundPlayer");
                null !== e && e.play()
            } else if (1 == t) {
                var i = document.getElementById("soundPlayer");
                null !== i && i.play()
            } else if (2 == t) {
                var e = document.getElementById("bgSoundPlayer");
                null !== e && e.play()
            }
        },
        U = function (t) {
            var e = document.getElementById("soundPlayer");
            null !== e && (e.volume = t);
            var i = document.getElementById("bgSoundPlayer");
            null !== i && (i.volume = t)
        };
    a.Class.extend({
        currentStage: null
    }), a.Sprite.extend("Plane", {
        init: function (t) {
            this._super(t, {
                sheet: "plane",
                sprite: "plane",
                x: a.width / 2
            }), this.p.y = a.height - this.p.h / 2 - 30, this.add("animation"), this.add("tween"), this.play("plane1")
        },
        fire: function () {
            if (!a.state.get("firing")) {
                var t = a("Comp").first();
                if (t) {
                    a.state.set("firing", !0);
                    var e, i = t.p.x - a.width / 2,
                        s = a.height - t.p.y,
                        n = 90 - 180 * Math.acos(i / Math.sqrt(i * i + s * s)) / Math.PI,
                        o = this.stage.insert(new a.Rocket1({
                            angle: n,
                            wing: -20,
                            twin: e
                        }));
                    e = this.stage.insert(new a.Rocket1({
                        angle: n,
                        wing: 20,
                        twin: o
                    })), o.p.twin = e, I.val(""), I.focus(), a.userCode.toLowerCase() == t.p.code.toLowerCase() || "xxxx" == a.userCode.toLowerCase() ? (t.p.inTarget = !0, o.animate({
                        x: t.p.x,
                        y: t.p.y
                    }), e.animate({
                        x: t.p.x,
                        y: t.p.y
                    }), F(h)) : (e.animate({
                        x: a.width / 2,
                        y: a.height - 170,
                        angle: 180
                    }), F(h), o.animate({
                        x: a.width / 2,
                        y: a.height - 170,
                        angle: 180
                    }, {
                        callback: function () {
                            o.destroy(), e.destroy(), F(u);
                            var t = this.stage.insert(new a.Explo({
                                x: a.width / 2,
                                y: a.height - 170
                            }));
                            t.animate({
                                x: t.p.x,
                                y: t.p.y,
                                angle: 180
                            }, 2, {
                                callback: function () {
                                    t.destroy(), a.state.set("firing", !1)
                                }
                            })
                        }
                    }))
                }
            }
        },
        fireRock3: function () {
            if (!(a.state.get("firing") || x >= A.length)) {
                var t = l("RadarName").first();
                if (t) {
                    a.state.set("firing", !0);
                    var e, r = (t.p.x - a.width / 2, a.height - t.p.y, 0),
                        c = this.stage.insert(new a.Rocket3({
                            angle: r,
                            wing: -20,
                            twin: e
                        }));
                    if (e = this.stage.insert(new a.Rocket3({
                        angle: r,
                        wing: 20,
                        twin: c
                    })), c.p.twin = e, I.val(""), I.focus(), a.userCode.toLowerCase() == A[x].code.toLowerCase() || "zzzz" == a.userCode.toLowerCase()) {
                        S = !0, o = l.currentStage.insert(new l.PilotScreen({
                            x: 140,
                            y: l.height - 90,
                            z: 1e3
                        })), l.ctx.font = "18px Arial";
                        var p = l.ctx.measureText(R[A[x].index]).width;
                        p = 140 - p / 2, n = l.currentStage.insert(new l.RadarComp({
                            x: p,
                            y: l.height - 150,
                            code: A[x].code
                        })), e.animate({
                            x: a.width / 2,
                            y: 0
                        }), c.animate({
                            x: a.width / 2,
                            y: 0
                        }, {
                            callback: function () {
                                c.destroy(), e.destroy(), i = l.currentStage.insert(new l.Rocket3({
                                    wing: -20,
                                    twin: s
                                })), s = l.currentStage.insert(new l.Rocket3({
                                    wing: 20,
                                    twin: i
                                })), i.p.twin = s, i.animate({
                                    x: 140,
                                    y: l.height - 150
                                }, {
                                    callback: function () {
                                        s.destroy(), i.destroy(), n.destroy(), A[x].shoot = !0, a.state.set("rightShoots", a.state.get("rightShoots") + 1), D.push(!0);
                                        var t = a.currentStage.insert(new a.Explo({
                                            x: 140,
                                            y: a.height - 150,
                                            scale: .75
                                        }));
                                        F(d), t.animate({
                                            x: t.p.x,
                                            y: t.p.y,
                                            angle: 180
                                        }, 2, {
                                            callback: function () {
                                                t.destroy(), x++, S = !1, o.destroy(), a.state.set("firing", !1)
                                            }
                                        })
                                    }
                                }), s.animate({
                                    x: 140,
                                    y: l.height - 150
                                })
                            }
                        }), F(h)
                    } else a.state.set("wrongShoots", a.state.get("wrongShoots") + 1), e.animate({
                        x: a.width / 2,
                        y: a.height - 170,
                        angle: 180
                    }), c.animate({
                        x: a.width / 2,
                        y: a.height - 170,
                        angle: 180
                    }, {
                        callback: function () {
                            c.destroy(), e.destroy();
                            var t = this.stage.insert(new a.Explo({
                                x: a.width / 2,
                                y: a.height - 170
                            }));
                            t.animate({
                                x: t.p.x,
                                y: t.p.y,
                                angle: 180
                            }, 2, {
                                callback: function () {
                                    t.destroy(), a.state.set("firing", !1)
                                }
                            })
                        }
                    })
                }
            }
        },
        step: function () {
            var t = a("Comp").first();
            if (t) {
                var e = t.p.x - a.width / 2,
                    i = a.height - t.p.y,
                    s = 90 - 180 * Math.acos(e / Math.sqrt(e * e + i * i)) / Math.PI;
                this.animate({
                    angle: s
                })
            } else this.animate({
                angle: 0
            })
        }
    }), a.Sprite.extend("Comp", {
        init: function (t) {
            this._super(t, {
                y: -30,
                w: 0,
                h: 30,
                code: "",
                index: 0,
                textWidth: 0,
                inTarget: !1,
                speed: 39.5,
                ended: !1
            }), this.on("hit", function (t) {
                if (1 == this.p.inTarget && (t.obj.p.type & a.SPRITE_FRIENDLY) == a.SPRITE_FRIENDLY && (t.obj.isA("Rocket1") || t.obj.isA("Rocket2") || t.obj.isA("Rocket3"))) {
                    t.obj.p.twin.destroy(), t.obj.destroy(), A[this.p.index].shoot = !0, this.destroy(), a.state.set("rightShoots", a.state.get("rightShoots") + 1), D.push(!0);
                    var e = this.stage.insert(new a.Explo({
                        x: this.p.x,
                        y: this.p.y
                    }));
                    F(d), e.animate({
                        x: e.p.x,
                        y: e.p.y,
                        angle: 180
                    }, 2, {
                        callback: function () {
                            e.destroy(), a.state.set("firing", !1)
                        }
                    })
                }
            })
        },
        step: function (t) {
            if (this.stage.collide(this), this.p.y += this.p.speed * t, this.p.y >= a.height - 200 && !this.p.inTarget) {
                this.destroy(), F(u), this.stage.insert(new a.CodeText({
                    code: this.p.code,
                    x: this.p.x,
                    y: this.p.y
                })), a.state.set("wrongShoots", a.state.get("wrongShoots") + 1), D.push(!1);
                var e = this.stage.insert(new a.Explo({
                    scale: 1.4,
                    x: a.width / 2,
                    y: a.height - 90
                })),
                    i = a.state.get("lives");
                i > 0 && (a.state.set("lives", a.state.get("lives") - 1), C.html(a.state.get("lives"))), e.animate({
                    x: e.p.x,
                    y: e.p.y,
                    angle: 180
                }, 2, {
                    callback: function () {
                        e.destroy(), a.state.set("firing", !1), 0 >= i && a.stageScene("gameOver")
                    }
                })
            }
        },
        draw: function (t) {
            if (x <= A.length) {
                t.fillStyle = "yellow", t.font = "23px Arial", t.textBaseline = "middle";
                var e = this.p.textWidth / 2 * -1;
                t.fillText(R[A[this.p.index].index], e, 0)
            }
        }
    }), a.Sprite.extend("CodeText", {
        init: function (t) {
            this._super(t, {
                y: -30,
                w: a.width / 3,
                h: 30,
                code: "",
                speed: 8,
                opacity: 1,
                time: 0
            })
        },
        step: function (t) {
            this.p.time += t, this.p.y -= this.p.speed * t, this.p.opacity -= .01, this.p.opacity <= .05 && this.destroy()
        },
        draw: function (t) {
            t.globalAlpha = this.p.opacity, t.fillStyle = "red", t.font = "23px Arial", t.textBaseline = "middle";
            var e = t.measureText(this.p.code).width / 2;
            t.fillText(this.p.code, -e, 0)
        }
    }), a.Sprite.extend("Rocket1", {
        init: function (t) {
            this._super(t, {
                sheet: "rocket1",
                sprite: "rocket1",
                wing: 0,
                scale: 1.5,
                twin: null,
                type: a.SPRITE_FRIENDLY
            }), this.p.x = a.width / 2 + this.p.wing, this.p.y = a.height - this.p.h / 2 - 30, this.add("animation"), this.add("tween"), this.play("run")
        }
    }), a.Sprite.extend("Rocket2", {
        init: function (t) {
            this._super(t, {
                sheet: "rocket2",
                sprite: "rocket2",
                wing: 0,
                scale: 1.5,
                twin: null,
                type: a.SPRITE_FRIENDLY
            }), this.p.x = a.width / 2 + this.p.wing, this.p.y = a.height - this.p.h / 2 - 30, this.add("animation"), this.add("tween"), this.play("run")
        }
    }), a.Sprite.extend("Rocket3", {
        init: function (t) {
            this._super(t, {
                sheet: "rocket3",
                sprite: "rocket3",
                wing: 0,
                scale: 1.5,
                twin: null,
                type: a.SPRITE_FRIENDLY
            }), this.p.x = a.width / 2 + this.p.wing, this.p.y = a.height - this.p.h / 2 - 30, this.add("animation"), this.add("tween"), this.play("run")
        },
        step: function () {
            this.p.y <= 0 && this.destroy()
        }
    }), a.Sprite.extend("Explo", {
        init: function (t) {
            this._super(t, {
                sheet: "explo",
                sprite: "explo",
                type: a.SPRITE_NONE
            }), this.add("animation"), this.add("tween"), this.play("run")
        },
        des: function () {
            this.destroy()
        }
    }), a.Sprite.extend("GO", {
        init: function (t) {
            this._super(t, {
                sheet: "gameOver1",
                speed: 40,
                scale: .6,
                x: a.width / 2,
                y: -20
            }), this.on("hit", function (t) {
                this.destroy(), t.obj.destroy();
                var e = this.stage.insert(new a.Explo({
                    x: this.p.x,
                    y: this.p.y,
                    scale: 4
                }));
                F(d), e.animate({
                    x: e.p.x,
                    y: e.p.y,
                    angle: 180
                }, 2, {
                    callback: function () {
                        l.stageScene(""), a.stageScene("finalScore"), e.destroy(), this.destroy()
                    }
                })
            })
        },
        step: function (t) {
            this.p.y += this.p.speed * t, this.stage.collide(this)
        }
    }), a.Sprite.extend("IntroLogo", {
        init: function (t) {
            this._super(t, {
                y: a.height / 2,
                x: a.width / 2,
                sheet: "introLogo",
                opacity: 0,
                showTime: 0,
                showDir: !0
            })
        },
        step: function (t) {
            this.p.showDir ? this.p.opacity >= 1 ? (this.p.showTime += 2 * t, this.p.showTime >= 1 && (this.p.showDir = !1)) : this.p.opacity += .32 : this.p.opacity <= .32 ? (this.destroy(), this.stage.insert(new a.IntroName)) : this.p.opacity -= .032
        }
    }), a.Sprite.extend("IntroName", {
        init: function (t) {
            this._super(t, {
                y: a.height / 2,
                x: a.width / 2,
                sheet: "introName",
                opacity: 0,
                showTime: 0,
                showDir: !0
            })
        },
        step: function (t) {
            this.p.showDir ? this.p.opacity >= 1 ? (this.p.showTime += 2 * t, this.p.showTime >= 1 && (this.p.showDir = !1)) : this.p.opacity += .032 : this.p.opacity <= .032 ? (this.destroy(), $("#menuContainer").css("visibility", "visible")) : this.p.opacity -= .032
        }
    });
    a.Sprite.extend("Grid", {
        init: function (t) {
            this._super(t, {
                y: 0,
                x: 10,
                w: a.width - 25,
                h: a.height - 100,
                time: 0,
                index: 0,
                index2: 0,
                blockWidth: (a.width - 40) / 16 + (a.width - 40) / 16 / 15,
                blockMax: a.height - 12
            })
        },
        step: function (e) {
            if (this.p.time += e, this.p.index2 >= A.length) return v = !0, void $("#tb_setting").css("visibility", "visible");
            var i = A[this.p.index2].sectorIndex,
                s = this.p.blockMax - 13 * t[i];
            t[i]++;
            var n = (this.p.w - this.p.blockWidth * i - 2 * i, this.p.w - this.p.blockWidth * i - 2 * i - this.p.blockWidth / 2),
                o = A[this.p.index2].shoot ? "green" : "red",
                l = document.createElementNS(c, "g"),
                d = document.createElementNS(c, "rect"),
                h = document.createElementNS(c, "text");
            l.setAttributeNS(null, "transform", "translate(" + n + ",-30)"), d.setAttributeNS(null, "x", 0), d.setAttributeNS(null, "y", 0), d.setAttributeNS(null, "height", "12"), d.setAttributeNS(null, "width", this.p.blockWidth), d.setAttributeNS(null, "fill", o), l.setAttributeNS(null, "alt", R[A[this.p.index2].index]);
            var p = a.ctx.font;
            a.ctx.font = "11.3px Arial";
            var u = (this.p.blockWidth - a.ctx.measureText(A[this.p.index2].code).width) / 2;
            h.setAttributeNS(null, "x", u), h.setAttributeNS(null, "y", 11), h.setAttributeNS(null, "fill", "yellow"), h.setAttributeNS(null, "font-size", 11), h.setAttributeNS(null, "font-family", "Arial");
            var g = document.createTextNode(A[this.p.index2].code);
            h.appendChild(g), a.ctx.font = p, l.appendChild(d), l.appendChild(h);
            var f = $(r),
                x = f.offset(),
                y = $(l),
                b = $("#tooltip"),
                m = $("#toolCont");
            m.css("left", 0), m.css("top", 0), m.css("width", f.width()), m.css("height", f.height() + x.top);
            var w = f.width() + x.left,
                k = f.height() + x.top;
            y.bind("mouseover", function () {
                b.css("visibility", "visible"), b.text(y.attr("alt"))
            }), y.bind("mouseout", function () {
                b.css("visibility", "hidden")
            }), y.bind("mousemove", function (t) {
                t.pageX + 20 + b.width() < w ? b.css("left", t.pageX - x.left + 20) : b.css("left", t.pageX - (20 + b.width() + x.left)), t.pageY + 20 + b.height() < k ? b.css("top", t.pageY + 20 - m.offset().top) : b.css("top", t.pageY - (20 + b.height() + m.offset().top))
            }), r.appendChild(l), this.stage.insert(new a.GridBlock({
                x: n,
                object: l,
                w: this.p.blockWidth,
                max: s
            })), this.p.index2++, this.p.time = 0
        }
    }), a.Sprite.extend("GridBlock", {
        init: function (t) {
            this._super(t, {
                y: -30,
                x: 0,
                w: 0,
                h: 12,
                code: "",
                object: null,
                speed: 20,
                max: 0,
                done: !1
            })
        },
        step: function () {
            this.p.done || (this.p.y + this.p.speed < this.p.max ? this.p.y += this.p.speed : (this.p.y = this.p.max, this.p.done = !0), this.p.object.setAttributeNS(null, "transform", "translate(" + this.p.x + "," + this.p.y + ")"))
        }
    }), a.Sprite.extend("CodeBlock", {
        init: function (t) {
            this._super(t, {
                y: -30,
                x: 0,
                w: 0,
                h: 12,
                code: "",
                color: "",
                speed: 20,
                max: 0,
                done: !1
            })
        },
        step: function () {
            this.p.done || (this.p.y + this.p.speed < this.p.max ? this.p.y += this.p.speed : (this.p.y = this.p.max, this.p.done = !0))
        },
        draw: function (t) {
            t.fillStyle = this.p.color, t.fillRect(-this.p.w / 2, -this.p.h / 2, this.p.w, this.p.h), t.fillStyle = "yellow", t.font = "11.3px Arial", t.textBaseline = "middle";
            var e = t.measureText(this.p.code).width / 2;
            t.fillText(this.p.code, -e, 0)
        }
    }), l.Sprite.extend("RadarComp", {
        init: function (t) {
            this._super(t, {
                y: -30,
                w: 0,
                h: 30,
                code: "",
                index: 0,
                textWidth: 0
            })
        },
        draw: function (t) {
            if (x < A.length) {
                t.fillStyle = "yellow", t.font = "18px Arial", t.textBaseline = "middle";
                var e = this.p.textWidth / 2 * -1;
                t.fillText(R[A[x].index], e, 0)
            }
        }
    }), l.Sprite.extend("RadarBG", {
        init: function (t) {
            this._super(t, {
                sheet: "rbg",
                x: l.width - 72,
                y: l.height - 72,
                z: 0,
                type: l.SPRITE_NONE
            })
        }
    }), l.Sprite.extend("RadarName", {
        init: function (t) {
            this._super(t, {
                w: 144,
                h: 144,
                x: l.width - 72,
                y: l.height - 72,
                txt_x: -20,
                txt_y: -72,
                speed: 20,
                follow: null,
                outY: !0,
                index: 0
            })
        },
        step: function (t) {
            if (this.p.txt_y += this.p.speed * t, 1 != S)
                if (this.p.txt_y >= 30 && 1 == this.p.outY)
                    if (x < A.length) {
                        x++;
                        var e = x - 1,
                            i = a.ctx.measureText(R[A[e].index]).width,
                            s = a.width / 3,
                            n = Math.floor(3 * Math.random()),
                            o = 0;
                        o = i > s ? 0 == n ? i / 2 : 2 == this.p.colIndex ? a.width - i / 2 - (i - s) : s / 2 + s * n : s / 2 + s * n, a.currentStage.insert(new a.Comp({
                            w: i,
                            code: A[e].code,
                            index: e,
                            x: o,
                            textWidth: i
                        })), this.p.outY = !1
                    } else {
                        if (this.p.txt_y < 72) return;
                        a.stageScene(""), $("#txtContainer").css("visibility", "hidden"), $("#btnPause").css("visibility", "hidden"), $("#bulletsList").css("visibility", "hidden"), a.stageScene("gameOver"), this.destroy()
                    } else this.p.txt_y >= 72 && (this.p.txt_y = -72, this.p.index = x, this.p.outY = !0)
        },
        draw: function (t) {
            if (x < A.length) {
                var e = document.createElement("canvas");
                e.width = 144, e.height = 144;
                var i = e.getContext("2d");
                i.translate(72, 72), i.rotate(this.p.follow.p.angle * Math.PI / 180), i.beginPath(), i.moveTo(0, 0), i.lineTo(0, 59), i.arc(0, 0, 59, .5 * Math.PI, Math.PI), i.closePath(), i.clip(), i.rotate(-this.p.follow.p.angle * Math.PI / 180), i.fillStyle = "#b5ffa6", i.textBaseline = "top", i.font = "14px Arial", i.fillText(R[A[this.p.index].index], this.p.txt_x, this.p.txt_y), t.drawImage(e, -72, -72)
            }
        }
    }), l.Sprite.extend("PilotScreen", {
        init: function (t) {
            this._super(t, {
                sheet: "screen",
                opacity: .7
            })
        }
    }), l.Sprite.extend("Rocket3", {
        init: function (t) {
            this._super(t, {
                sheet: "rocket3",
                sprite: "rocket3",
                wing: 0,
                scale: .75,
                twin: null,
                type: l.SPRITE_FRIENDLY
            }), this.p.x = 140 + this.p.wing, this.p.y = l.height, this.add("animation"), this.add("tween"), this.play("run")
        }
    }), l.Sprite.extend("RadarLight", {
        init: function (t) {
            this._super(t, {
                sheet: "rlt",
                x: l.width - 72,
                y: l.height - 72,
                z: 0,
                opacity: .9,
                type: l.SPRITE_NONE
            }), this.add("tween")
        },
        step: function () {
            this.p.angle += 6
        }
    }), l.Sprite.extend("ScoreBar", {
        init: function (t) {
            this._super(t, {
                y: 30,
                x: l.width / 2,
                w: a.width / 2.1,
                h: 25,
                rghts: 0,
                wrongs: 0,
                rightText: 0,
                wrongText: 0,
                seg: 250 / A.length
            })
        },
        draw: function (t) {
            var e = a.width / 3,
                i = a.state.get("rightShoots") / A.length * e,
                s = a.state.get("wrongShoots") / A.length * e;
            this.p.rightText = a.state.get("rightShoots") / A.length * 100, this.p.wrongText = a.state.get("wrongShoots") / A.length * 100;
            var n = (a.width / 2.1 - a.width / 3) / 2;
            t.save(), t.translate(a.width / -4.2, this.p.y / -2);
            var o = t.createLinearGradient(0, 0, 0, 25);
            if (o.addColorStop(0, "gray"), o.addColorStop(.5, "white"), o.addColorStop(1, "gray"), t.fillStyle = o, t.fillRect(n, 0, this.p.w - 2 * n, this.p.h), t.textBaseline = "middle", t.font = "bold 14px Arial", t.fillStyle = "#a90000", t.fillText(Number(this.p.wrongText).toFixed(0) + "%", n / 6, this.p.h / 2), t.fillStyle = "green", t.fillText(Number(this.p.rightText).toFixed(0) + "%", e + n + n / 6, this.p.h / 2), i > this.p.rghts || s > this.p.wrongs) {
                this.p.wrongs += (s - this.p.wrongs) / 20, this.p.rghts += (i - this.p.rghts) / 20;
                var l = t.createLinearGradient(0, 0, 0, 25);
                l.addColorStop(0, "#a90000"), l.addColorStop(.5, "#f58282"), l.addColorStop(1, "#a90000"), t.fillStyle = l, t.fillRect(n, 0, this.p.wrongs, this.p.h);
                var r = t.createLinearGradient(0, 0, 0, 25);
                r.addColorStop(0, "green"), r.addColorStop(.5, "#4efa3a"), r.addColorStop(1, "green"), t.fillStyle = r, t.fillRect(this.p.wrongs + n, 0, this.p.rghts, this.p.h)
            }
            t.restore()
        }
    }), l.Sprite.extend("TopBanner", {
        init: function (t) {
            this._super(t, {
                sheet: "tb",
                x: l.width / 2,
                y: 15
            })
        }
    }), a.animations("plane", {
        plane1: {
            frames: [0, 1, 2, 3],
            rate: 1 / 6
        },
        plane2: {
            frames: [4, 5, 6, 7],
            rate: 1 / 6
        },
        plane3: {
            frames: [8, 9, 10, 11],
            rate: 1 / 6
        }
    }), a.animations("rocket1", {
        run: {
            frames: [0, 1],
            rate: 1 / 8
        }
    }), a.animations("rocket2", {
        run: {
            frames: [0, 1],
            rate: 1 / 8
        }
    }), a.animations("rocket3", {
        run: {
            frames: [0, 1],
            rate: 1 / 8
        }
    }), a.animations("explo", {
        run: {
            frames: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12],
            rate: 1 / 6,
            loop: !1,
            trigger: "des"
        }
    }), l.animations("rocket3", {
        run: {
            frames: [0, 1],
            rate: 1 / 8
        }
    }), l.scene("level1BG", function (t) {
        t.insert(new l.RadarBG), t.insert(new l.RadarName({
            follow: t.insert(new l.RadarLight)
        })), t.insert(new l.TopBanner), t.insert(new l.ScoreBar), l.currentStage = t
    }), a.scene("finalScore", function (t) {
        X(0), $("#btnSound").css("visibility", "hidden"), t.insert(new a.Grid), $("#bulletsList").css("visibility", "hidden")
    }), a.scene("intro", function (t) {
        t.insert(new a.IntroLogo)
    }), a.scene("level1", function (t) {
        v = !1, X(0), l.load(["ICON.png"], function () {
            l.sheet("rbg", "ICON.png", {
                tilew: 144,
                tileh: 144,
                sx: 80,
                sy: 154
            }), l.sheet("rlt", "ICON.png", {
                tilew: 144,
                tileh: 144,
                sx: 260,
                sy: 154
            }), l.sheet("tb", "ICON.png", {
                tilew: 364,
                tileh: 100,
                sx: 440,
                sy: 240
            }), l.sheet("screen", "ICON.png", {
                tilew: 258,
                tileh: 180,
                sx: 804,
                sy: 155
            }), l.sheet("rocket3", "ICON.png", {
                tilew: 20,
                tileh: 60,
                sx: 40,
                sy: 150,
                frames: 2
            }), l.stageScene("level1BG"), l.Class.extend({
                scoreMeter: "",
                lebvelMeter: null
            })
        }), $("#menuContainer").css("visibility", "hidden"), $("#headBorderText").css("visibility", "visible"), $("#txtContainer").css("visibility", "visible"), $("#btnPause").css("visibility", "visible"), $("#btnSound").css("visibility", "visible"), $("#bulletsList").css("visibility", "visible"), $("#tb_setting").css("visibility", "visible"), $("#tb_lives").css("visibility", "visible"), $("#rock1").bind("click", function () {
            e(1)
        }), $("#rock2").bind("click", function () {
            e(2)
        }), $("#rock3").bind("click", function () {
            e(3)
        }), e = function (t) {
            switch ($("#rock1").removeClass("Blockselection"), $("#rock2").removeClass("Blockselection"), $("#rock3").removeClass("Blockselection"), $("#rock1").removeClass("Block"), $("#rock2").removeClass("Block"), $("#rock3").removeClass("Block"), t) {
                case 1:
                    $("#rock1").addClass("Blockselection"), $("#rock2").addClass("Block"), $("#rock3").addClass("Block");
                    break;
                case 2:
                    $("#rock2").addClass("Blockselection"), $("#rock1").addClass("Block"), $("#rock3").addClass("Block");
                    break;
                case 3:
                    $("#rock3").addClass("Blockselection"), $("#rock1").addClass("Block"), $("#rock2").addClass("Block")
            }
            y = t, I.focus()
        }, e(1), a.ctx.font = "23px Arial", B.html(f), C.html(g), I.val(""), I.focus(), I.bind("keypress", function (t) {
            if (13 == t.keyCode) {
                var e = new String;
                if (e = I.val(), e.length < 4) return;
                a.userCode = I.val();
                var i = a("Comp").first(),
                    s = l("RadarName").first();
                if (null == i || a.userCode.toLowerCase() != i.p.code.toLowerCase() && "xxxx" != a.userCode.toLowerCase())
                    if (null != s && x < A.length && (a.userCode.toLowerCase() == A[x].code.toLowerCase() || "zzzz" == a.userCode.toLowerCase())) k.fireRock3();
                    else switch (y) {
                        case 1:
                            k.fire();
                            break;
                        case 2:
                            k.fireRock2();
                            break;
                        case 3:
                            k.fireRock3()
                    } else k.fire()
            }
        }), a.state.on("change.lives", this, function () {
            C.html(a.state.get("lives"))
        }), a.state.on("change.shoots", this, function () {
            B.html(a.state.get("shoots"))
        }), k = t.insert(new a.Plane), a.state.reset({
            firing: !1,
            lives: A.length,
            shoots: f,
            rightShoots: 0,
            wrongShoots: 0
        }), C.html(a.state.get("lives")), a.currentStage = t, H(p)
    }), a.scene("gameOver", function (t) {
        X(0), t.insert(new a.GO);
        var e = t.insert(new a.Plane);
        H(p), e.animate({
            x: a.width / 2,
            y: 0
        }, 2, {
            delay: 4
        }), $("#tb_setting").css("visibility", "hidden")
    }), a.scene("empty", function () {
        X(0)
    }), a.load(["ICON.png"], function () {
        $("#page-wrap").css("visibility", "visible"), a.sheet("plane", "ICON.png", {
            tilew: 55,
            tileh: 95,
            sx: 0,
            sy: 0,
            frames: 12
        }), a.sheet("rocket1", "ICON.png", {
            tilew: 10,
            tileh: 60,
            sx: 0,
            sy: 150,
            frames: 2
        }), a.sheet("rocket2", "ICON.png", {
            tilew: 10,
            tileh: 60,
            sx: 20,
            sy: 150,
            frames: 2
        }), a.sheet("rocket3", "ICON.png", {
            tilew: 20,
            tileh: 60,
            sx: 40,
            sy: 150,
            frames: 2
        }), a.sheet("explo", "ICON.png", {
            tilew: 63,
            tileh: 59,
            sx: 0,
            sy: 93,
            frames: 13
        }), a.sheet("introLogo", "ICON.png", {
            tilew: 380,
            tileh: 90,
            sx: 680,
            sy: 348
        }), a.sheet("introName", "ICON.png", {
            tilew: 380,
            tileh: 90,
            sx: 680,
            sy: 0
        }), a.sheet("gameOver1", "ICON.png", {
            tilew: 568,
            tileh: 109,
            sx: 0,
            sy: 340
        }), a.sheet("gameOver2", "ICON.png", {
            tilew: 568,
            tileh: 110,
            sx: 0,
            sy: 450
        }), Y();
        var t = !1;
        $("#btnNewGame").bind("click", function () {
            w = !1, $("#menuContainer").css("visibility", "hidden"), n()
        }), $("#btnSetting").bind("click", function () {
            h()
        }), $("#btnHelp").bind("click", function () { }), $("#btnExit").bind("click", function () {
            funExit()
        }), $("#btnResume").bind("click", function () {
            a.stage().unpause(), l.stage().unpause(), l.stage().show(), a.stage().show(), $("#txtContainer").css("visibility", "visible"), $("#btnPause").css("visibility", "visible"), $("#btnSound").css("visibility", "visible"), $("#bulletsList").css("visibility", "visible"), $("#headBorderText").css("visibility", "visible"), $("#tb_setting").css("visibility", "visible"), $("#tb_lives").css("visibility", "visible"), $("#menuOption").css("visibility", "hidden"), q(0)
        }), $("#btnReset").bind("click", function () {
            w = !0, $("#menuOption").css("visibility", "hidden"), n()
        }), $("#btnChangeSetting").bind("click", function () {
            e()
        }), $("#btnGameHelp").bind("click", function () {
            i()
        }), $("#btnStartPage").bind("click", function () {
            s()
        });
        var e = function () { },
            i = function () { },
            s = function () { };
        $("#listMenu *").click(function () {
            if (0 == this.checked) $("#option1").attr("checked", "");
            else {
                for (var t = document.forms[0].sector, e = 0; e < t.length; e++)
                    if (0 == t[e].checked) return;
                $("#option1").attr("checked", "checked")
            }
        }), $("#option1").click(function () {
            {
                var t = document.getElementById("option1");
                document.forms[0].sector
            }
            1 == t.checked ? $("#listMenu *").attr("checked", "checked") : $("#listMenu *:not(#tasi)").attr("checked", "")
        }), $("#rdCom").click(function () {
            $("#option1").attr("disabled", "disabled"), $("#allSectorCell").addClass("allSectorDisabled"), $("#listMenu *").attr("disabled", "disabled"), $("#listMenu").addClass("ListContainerHidden"), $("#option1").attr("checked", "checked"), $("#listMenu *").attr("checked", "checked")
        }), $("#rdTr").click(function () {
            $("#option1").attr("disabled", ""), $("#allSectorCell").removeClass("allSectorDisabled"), $("#listMenu *:not(#tasi)").attr("disabled", ""), $("#listMenu").removeClass("ListContainerHidden"), $("#option1").attr("checked", ""), $("#listMenu *:not(#tasi)").attr("checked", "")
        });
        var n = function () {
            $("#menuSectionList").css("visibility", "visible")
        },
            o = function (t) {
                switch ($("#rock1").removeClass("Blockselection"), $("#rock2").removeClass("Blockselection"), $("#rock3").removeClass("Blockselection"), $("#rock1").removeClass("Block"), $("#rock2").removeClass("Block"), $("#rock3").removeClass("Block"), t) {
                    case 1:
                        $("#rock1").addClass("Blockselection"), $("#rock2").addClass("Block"), $("#rock3").addClass("Block");
                        break;
                    case 2:
                        $("#rock2").addClass("Blockselection"), $("#rock1").addClass("Block"), $("#rock3").addClass("Block");
                        break;
                    case 3:
                        $("#rock3").addClass("Blockselection"), $("#rock1").addClass("Block"), $("#rock2").addClass("Block")
                }
                y = t, I.focus()
            };
        $("#listDone").bind("click", function () {
            z(), $("#menuSectionList").css("visibility", "hidden"), O(), t ? a.stageScene("finalScore") : (a.stageScene("level1"), I.val(""), o(1))
        }), $("#listCancel").bind("click", function () {
            W(), $("#menuContainer").css("visibility", "visible"), $("#menuSectionList").css("visibility", "hidden")
        });
        var c = !1;
        $("#btnPause").bind("click", function () {
            0 == c ? (a.stage().pause(), l.stage().pause(), l.stage().hide(), a.stage().hide(), $("#txtContainer").css("visibility", "hidden"), $("#bulletsList").css("visibility", "hidden"), $("#headBorderText").css("visibility", "hidden"), $("#tb_setting").css("visibility", "hidden"), $("#tb_lives").css("visibility", "hidden"), X(0), c = !0) : (a.stage().unpause(), l.stage().unpause(), l.stage().show(), a.stage().show(), $("#txtContainer").css("visibility", "visible"), $("#bulletsList").css("visibility", "visible"), $("#headBorderText").css("visibility", "visible"), $("#tb_setting").css("visibility", "visible"), $("#tb_lives").css("visibility", "visible"), q(0), c = !1), I.focus()
        });
        var d = !1;
        $("#btnSound").bind("click", function () {
            var t = $("#soundIcon");
            0 == d ? (U(0), t.attr("src", "/Areas/BcGame/SImages/soundoff.png"), d = !0) : (U(1), t.attr("src", "../../SImages/soundon.png"), d = !1), I.focus()
        }), $("#tb_setting").bind("click", function () {
            a.stage().pause(), l.stage().pause(), l.stage().hide(), a.stage().hide(), X(0), $("#txtContainer").css("visibility", "hidden"), $("#btnPause").css("visibility", "hidden"), $("#btnSound").css("visibility", "hidden"), $("#bulletsList").css("visibility", "hidden"), $("#headBorderText").css("visibility", "hidden"), $("#tb_setting").css("visibility", "hidden"), $("#tb_lives").css("visibility", "hidden"), v ? ($(r).empty(), $("#menuContainer").css("visibility", "visible")) : $("#menuOption").css("visibility", "visible")
        });
        var h = function () { };
        a.stageScene("intro")
    }, {
        progressCallback: function (t, e) {
            var i = document.getElementById("loading_progress");
            i.style.width = Math.floor(t / e * 100) + "%"
        }
    })
});