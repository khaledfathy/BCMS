/*jslint */
/*global AdobeEdge: false, window: false, document: false, console:false, alert: false */
(function (compId) {

    "use strict";
    var im='images/',
        aud='media/',
        vid='media/',
        js='js/',
        fonts = {
        },
        opts = {
            'gAudioPreloadPreference': 'auto',
            'gVideoPreloadPreference': 'auto'
        },
        resources = [
        ],
        scripts = [
            js+"jquery-2.0.3.min.js"
        ],
        symbols = {
            "stage": {
                version: "5.0.0",
                minimumCompatibleVersion: "5.0.0",
                build: "5.0.0.375",
                scaleToFit: "both",
                centerStage: "both",
                resizeInstances: false,
                content: {
                    dom: [
                        {
                            id: 'MainLine',
                            type: 'rect',
                            rect: ['19px', '187px', '0', '3px', 'auto', 'auto'],
                            fill: ["rgba(192,192,192,1)"],
                            stroke: [0,"rgba(0,0,0,1)","none"]
                        },
                        {
                            id: 'acqezd8Ri2',
                            type: 'image',
                            rect: ['8', '171px', '85', '44', 'auto', 'auto'],
                            fill: ["rgba(0,0,0,0)",im+"acqezd8Ri.png",'0px','0px'],
                            transform: [[],[],[],[],['50%','51%']]
                        },
                        {
                            id: 'Group42',
                            type: 'group',
                            rect: ['35', '40px', '71', '184px', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2',
                                type: 'rect',
                                rect: ['13', '126', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'Ellipse',
                                type: 'ellipse',
                                rect: ['9', '143', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1.00)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy3',
                                type: 'text',
                                rect: ['2', '170', 'auto', 'auto', 'auto', 'auto'],
                                text: "1935",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "700", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy2',
                                type: 'text',
                                rect: ['-30px', '107px', '95px', '26px', 'auto', 'auto'],
                                text: "أول شركة مساهمة",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "700", "none", "", "break-word", ""],
                                transform: [[],[],[],[],['50%','49%']]
                            }]
                        },
                        {
                            id: 'Group37',
                            type: 'group',
                            rect: ['210', '76px', '58', '148', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy5',
                                type: 'rect',
                                rect: ['11', '90', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy5',
                                type: 'ellipse',
                                rect: ['7', '107', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy13',
                                type: 'text',
                                rect: ['0', '134', 'auto', 'auto', 'auto', 'auto'],
                                text: "1975",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy12',
                                type: 'text',
                                rect: ['-48px', '70px', 'auto', 'auto', 'auto', 'auto'],
                                text: "أصبح 14 شركة مساهمة",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            }]
                        },
                        {
                            id: 'Group32',
                            type: 'group',
                            rect: ['385', '84px', '44', '140', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy10',
                                type: 'rect',
                                rect: ['-10px', '50px', '2px', '60px', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"],
                                transform: [[],['-40']]
                            },
                            {
                                id: 'Rectangle2Copy2',
                                type: 'rect',
                                rect: ['31px', '50px', '2px', '60px', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"],
                                transform: [[],['40']]
                            },
                            {
                                id: 'Rectangle2Copy',
                                type: 'rect',
                                rect: ['11', '82', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy23',
                                type: 'text',
                                rect: ['0', '126', 'auto', 'auto', 'auto', 'auto'],
                                text: "1984",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy22',
                                type: 'text',
                                rect: ['32px', '10px', 'auto', 'auto', 'auto', 'auto'],
                                text: "تحت رقابة<br>وزارة المالية<br>و مؤسسة النقد",
                                align: "center",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy',
                                type: 'text',
                                rect: ['-65px', '22px', 'auto', 'auto', 'auto', 'auto'],
                                text: "نشأت السوق <br>المالية المنتظمة",
                                align: "center",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'EllipseCopy10',
                                type: 'ellipse',
                                rect: ['7', '99', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            }]
                        },
                        {
                            id: 'Group27',
                            type: 'group',
                            rect: ['563', '98px', '53', '126', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy15',
                                type: 'rect',
                                rect: ['11', '68', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy15',
                                type: 'ellipse',
                                rect: ['7', '85', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy33',
                                type: 'text',
                                rect: ['0', '112', 'auto', 'auto', 'auto', 'auto'],
                                text: "2003",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy32',
                                type: 'text',
                                rect: ['-20px', '27px', 'auto', 'auto', 'auto', 'auto'],
                                text: "نشأت هيئة<br>السوق المالية",
                                align: "center",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            }]
                        },
                        {
                            id: 'Group23',
                            type: 'group',
                            rect: ['700', '89px', '41', '135', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy19',
                                type: 'rect',
                                rect: ['12', '77', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy19',
                                type: 'ellipse',
                                rect: ['8', '94', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy41',
                                type: 'text',
                                rect: ['1', '121', 'auto', 'auto', 'auto', 'auto'],
                                text: "2007",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy40',
                                type: 'text',
                                rect: ['-14px', '38px', 'auto', 'auto', 'auto', 'auto'],
                                text: "تأسيس<br>شركة تداول",
                                align: "center",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            }]
                        },
                        {
                            id: 'Text',
                            type: 'text',
                            rect: ['222px', '31px', '399px', '32px', 'auto', 'auto'],
                            text: "مراحل تطور السوق المالية السعودية",
                            align: "center",
                            font: ['Arial, Helvetica, sans-serif', [30, "px"], "rgba(0,0,0,1)", "700", "none", "", "break-word", "normal"]
                        }
                    ],
                    style: {
                        '${Stage}': {
                            isStage: true,
                            rect: ['null', 'null', '850', '300px', 'auto', 'auto'],
                            overflow: 'hidden',
                            fill: ["rgba(255,255,255,1)"]
                        }
                    }
                },
                timeline: {
                    duration: 3500,
                    autoPlay: true,
                    data: [
                        [
                            "eid40",
                            "opacity",
                            3292,
                            167,
                            "linear",
                            "${Group23}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid26",
                            "opacity",
                            954,
                            167,
                            "linear",
                            "${Group37}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid31",
                            "opacity",
                            1789,
                            167,
                            "linear",
                            "${Group32}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid20",
                            "opacity",
                            0,
                            286,
                            "linear",
                            "${Group42}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid36",
                            "opacity",
                            2624,
                            167,
                            "linear",
                            "${Group27}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid2",
                            "width",
                            0,
                            3500,
                            "linear",
                            "${MainLine}",
                            '0px',
                            '750px'
                        ],
                        [
                            "eid80",
                            "left",
                            0,
                            3500,
                            "linear",
                            "${acqezd8Ri2}",
                            '8px',
                            '758px'
                        ]
                    ]
                }
            },
            "NYSE": {
                version: "5.0.0",
                minimumCompatibleVersion: "5.0.0",
                build: "5.0.0.375",
                scaleToFit: "none",
                centerStage: "none",
                resizeInstances: false,
                content: {
                    dom: [
                        {
                            type: 'rect',
                            id: 'Rectangle2',
                            stroke: [0, 'rgb(0, 0, 0)', 'none'],
                            rect: [12, 126, '2px', 44, 'auto', 'auto'],
                            fill: ['rgba(192,192,192,1)']
                        },
                        {
                            rect: [8, 143, 10, 10, 'auto', 'auto'],
                            borderRadius: ['50%', '50%', '50%', '50%'],
                            id: 'Ellipse',
                            stroke: [0, 'rgb(0, 0, 0)', 'none'],
                            type: 'ellipse',
                            fill: ['rgba(142,142,142,1.00)']
                        },
                        {
                            rect: [1, 170, 'auto', 'auto', 'auto', 'auto'],
                            id: 'Text',
                            text: '1792',
                            font: ['Arial, Helvetica, sans-serif', [11, 'px'], 'rgba(0,0,0,1)', '700', 'none', '', '', 'nowrap'],
                            type: 'text'
                        },
                        {
                            rect: [-15, 75, 'auto', 'auto', 'auto', 'auto'],
                            transform: [[0, 0, 0], ['-59', 0, 0], [0, 0], [1, 1, 1], ['50%', '50%']],
                            id: 'TextCopy',
                            text: 'نيويورك (NYSE)',
                            font: ['Arial, Helvetica, sans-serif', [14, 'px'], 'rgba(0,0,0,1)', '700', 'none', '', '', 'nowrap'],
                            type: 'text'
                        },
                        {
                            id: 'F15',
                            type: 'image',
                            rect: [30, 0, 40, 40, 'auto', 'auto'],
                            fill: ['rgba(0,0,0,0)', 'images/F15.png', '0px', '0px']
                        }
                    ],
                    style: {
                        '${symbolSelector}': {
                            rect: [null, null, 70, 184]
                        }
                    }
                },
                timeline: {
                    duration: 0,
                    autoPlay: true,
                    data: [

                    ]
                }
            },
            "international": {
                version: "5.0.0",
                minimumCompatibleVersion: "5.0.0",
                build: "5.0.0.375",
                scaleToFit: "none",
                centerStage: "none",
                resizeInstances: false,
                content: {
                    dom: [
                        {
                            type: 'rect',
                            borderRadius: ['20px 20px', '20px 20px', '20px 20px', '20px 20px'],
                            rect: [0, 0, '142px', '37px', 'auto', 'auto'],
                            id: 'Rectangle4',
                            stroke: ['1px', 'rgba(255,0,0,1.00)', 'solid'],
                            cursor: 'pointer',
                            fill: ['rgba(0,0,0,1.00)']
                        },
                        {
                            rect: [44, 4, 'auto', 'auto', 'auto', 'auto'],
                            font: ['Arial, Helvetica, sans-serif', [25, 'px'], 'rgba(255,255,255,1.00)', 'bold', 'none', 'normal', '', 'nowrap'],
                            align: 'left',
                            id: 'Text2',
                            text: 'العالمى',
                            cursor: 'pointer',
                            type: 'text'
                        }
                    ],
                    style: {
                        '${symbolSelector}': {
                            rect: [null, null, 144, 39]
                        }
                    }
                },
                timeline: {
                    duration: 0,
                    autoPlay: true,
                    data: [

                    ]
                }
            },
            "Arabic": {
                version: "5.0.0",
                minimumCompatibleVersion: "5.0.0",
                build: "5.0.0.375",
                scaleToFit: "none",
                centerStage: "none",
                resizeInstances: false,
                content: {
                    dom: [
                        {
                            type: 'rect',
                            borderRadius: ['20px 20px', '20px 20px', '20px 20px', '20px 20px'],
                            rect: [0, 0, '142px', '37px', 'auto', 'auto'],
                            id: 'Rectangle4Copy',
                            stroke: ['1px', 'rgb(255, 0, 0)', 'solid'],
                            cursor: 'pointer',
                            fill: ['rgba(0,0,0,1)']
                        },
                        {
                            rect: [44, 4, 'auto', 'auto', 'auto', 'auto'],
                            font: ['Arial, Helvetica, sans-serif', [25, 'px'], 'rgba(255,255,255,1)', 'bold', 'none', 'normal', '', 'nowrap'],
                            id: 'Text2Copy',
                            text: 'العربي<br>',
                            align: 'left',
                            type: 'text'
                        }
                    ],
                    style: {
                        '${symbolSelector}': {
                            rect: [null, null, 144, 39]
                        }
                    }
                },
                timeline: {
                    duration: 0,
                    autoPlay: true,
                    data: [

                    ]
                }
            },
            "Gulf": {
                version: "5.0.0",
                minimumCompatibleVersion: "5.0.0",
                build: "5.0.0.375",
                scaleToFit: "none",
                centerStage: "none",
                resizeInstances: false,
                content: {
                    dom: [
                        {
                            type: 'rect',
                            borderRadius: ['20px 20px', '20px 20px', '20px 20px', '20px 20px'],
                            rect: [0, 0, '142px', '37px', 'auto', 'auto'],
                            id: 'Rectangle4Copy2',
                            stroke: ['1px', 'rgb(255, 0, 0)', 'solid'],
                            cursor: 'pointer',
                            fill: ['rgba(0,0,0,1)']
                        },
                        {
                            rect: [44, 4, 'auto', 'auto', 'auto', 'auto'],
                            font: ['Arial, Helvetica, sans-serif', [25, 'px'], 'rgba(255,255,255,1)', 'bold', 'none', 'normal', '', 'nowrap'],
                            id: 'Text2Copy2',
                            text: 'الخليجي<br>',
                            align: 'left',
                            type: 'text'
                        }
                    ],
                    style: {
                        '${symbolSelector}': {
                            rect: [null, null, 144, 39]
                        }
                    }
                },
                timeline: {
                    duration: 0,
                    autoPlay: true,
                    data: [

                    ]
                }
            }
        };

    AdobeEdge.registerCompositionDefn(compId, symbols, fonts, scripts, resources, opts);

    if (!window.edge_authoring_mode) AdobeEdge.getComposition(compId).load("Untitled-1_edgeActions.js");
})("EDGE-431897187");
