/**
 * Adobe Edge: symbol definitions
 */
(function($, Edge, compId){
//images folder
var im='images/';

var fonts = {};
var opts = {
    'gAudioPreloadPreference': 'auto',

    'gVideoPreloadPreference': 'auto'
};
var resources = [
];
var symbols = {
"stage": {
    version: "4.0.0",
    minimumCompatibleVersion: "4.0.0",
    build: "4.0.0.359",
    baseState: "Base State",
    scaleToFit: "both",
    centerStage: "none",
    initialState: "Base State",
    gpuAccelerate: false,
    resizeInstances: false,
    content: {
            dom: [
            {
                id: 'GroupOne',
                type: 'group',
                rect: ['-6px', '517px','448','116','auto', 'auto'],
                c: [
                {
                    id: 'Rectangle',
                    type: 'rect',
                    rect: ['19px', '0px','427px','114px','auto', 'auto'],
                    clip: ['rect(0px 427px 114px 0px)'],
                    fill: ["rgba(255,255,255,1.00)"],
                    stroke: [1,"rgba(228,228,228,1.00)","solid"],
                    boxShadow: ["", 3, 1, 5, 0, "rgba(0,0,0,0.65098)"]
                },
                {
                    id: 'title1',
                    type: 'rect',
                    rect: ['14px', '4px','auto','auto','auto', 'auto']
                },
                {
                    id: 'Text4',
                    type: 'text',
                    rect: ['298px', '32px','92px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "المكتبة الألكترونية ",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy',
                    type: 'text',
                    rect: ['201px', '32px','92px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "العاب تعليمية",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy2',
                    type: 'text',
                    rect: ['104px', '32px','109px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "هيئة السوق المالية",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy3',
                    type: 'text',
                    rect: ['0px', '32px','109px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "اكاديمية البورصة",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy4',
                    type: 'text',
                    rect: ['294px', '63px','92px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "شريط الاسعار ",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy5',
                    type: 'text',
                    rect: ['204px', '63px','92px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "محفظة تجريبية ",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy6',
                    type: 'text',
                    rect: ['119px', '63px','92px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "الأختبارات",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                }]
            },
            {
                id: 'Group2',
                type: 'group',
                rect: ['-1', '403','510','110','auto', 'auto'],
                c: [
                {
                    id: 'Rectangle4',
                    type: 'rect',
                    rect: ['14px', '0px','494px','108px','auto', 'auto'],
                    clip: ['rect(0px 494px 108px 0px)'],
                    fill: ["rgba(255,255,255,1)"],
                    stroke: [1,"rgb(215, 214, 214)","solid"]
                },
                {
                    id: 'title2',
                    type: 'rect',
                    rect: ['9px', '3px','auto','auto','auto', 'auto'],
                    clip: ['rect(0px 182px 24px 0px)']
                },
                {
                    id: 'Text4Copy7',
                    type: 'text',
                    rect: ['349px', '27px','104px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "شريط اسعار أحترافي ",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy8',
                    type: 'text',
                    rect: ['267px', '27px','79px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "الملخص اليومي",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy9',
                    type: 'text',
                    rect: ['182px', '27px','79px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "العداد الاقتصادي",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy10',
                    type: 'text',
                    rect: ['91px', '27px','83px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "بورصة جرافيكس",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy14',
                    type: 'text',
                    rect: ['18px', '27px','65px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "خدمات الجوال",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy12',
                    type: 'text',
                    rect: ['349px', '55px','92px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "الماسح االأقتصادي",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy13',
                    type: 'text',
                    rect: ['235px', '55px','108px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "صفحة البتروكيماويات",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy11',
                    type: 'text',
                    rect: ['178px', '55px','54px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "جلف بيس",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy15',
                    type: 'text',
                    rect: ['91px', '55px','79px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "الخرائط الحرارية",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy18',
                    type: 'text',
                    rect: ['0px', '55px','79px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "الماسح الفني",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy16',
                    type: 'text',
                    rect: ['347px', '84px','79px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "صفحة المستثمر",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy17',
                    type: 'text',
                    rect: ['261px', '84px','79px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "الدبب والثيران",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy20',
                    type: 'text',
                    rect: ['219px', '84px','37px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "تك توق",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy19',
                    type: 'text',
                    rect: ['124px', '84px','79px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "صفحة المضارب",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy21',
                    type: 'text',
                    rect: ['4px', '84px','108px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "Market Caster",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 12, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                }]
            },
            {
                id: 'PRAMID-SERVICES3_01',
                type: 'image',
                rect: ['0px', '-1px','850px','99px','auto', 'auto'],
                fill: ["rgba(0,0,0,0)",im+"PRAMID-SERVICES3_01.png",'0px','0px']
            },
            {
                id: 'Group3',
                type: 'group',
                rect: ['8', '300','542','99','auto', 'auto'],
                c: [
                {
                    id: 'Rectangle5',
                    type: 'rect',
                    rect: ['5px', '0px','535px','97px','auto', 'auto'],
                    clip: ['rect(0px 535px 97px 0px)'],
                    fill: ["rgba(255,255,255,1.00)"],
                    stroke: [1,"rgb(228, 228, 228)","solid"]
                },
                {
                    id: 'Symbol_1',
                    type: 'rect',
                    rect: ['0px', '4px','auto','auto','auto', 'auto'],
                    clip: ['rect(0px 182px 24px 0px)']
                },
                {
                    id: 'Text4Copy22',
                    type: 'text',
                    rect: ['417px', '31px','64px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "متابعة محافظ",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy23',
                    type: 'text',
                    rect: ['322px', '31px','64px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "تقييم محافظ",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy25',
                    type: 'text',
                    rect: ['229px', '31px','69px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "تحليل محافظ",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy24',
                    type: 'text',
                    rect: ['136px', '31px','69px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "رادار البورصة",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy26',
                    type: 'text',
                    rect: ['30px', '31px','69px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "نادي البورصة ",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
                },
                {
                    id: 'Text4Copy27',
                    type: 'text',
                    rect: ['432px', '60px','40px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "ElKon",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 12, "rgba(21,21,21,1.00)", "700", "underline", "normal"]
                },
                {
                    id: 'Text4Copy28',
                    type: 'text',
                    rect: ['330px', '60px','63px','13px','auto', 'auto'],
                    cursor: ['pointer'],
                    text: "DR Trader",
                    align: "right",
                    font: ['Arial, Helvetica, sans-serif', 12, "rgba(21,21,21,1.00)", "700", "underline", "normal"]
                }]
            },
            {
                id: 'Rectangle7',
                type: 'rect',
                rect: ['12px', '208px','587px','86px','auto', 'auto'],
                clip: ['rect(0px 587px 86px 0px)'],
                fill: ["rgba(255,255,255,1)"],
                stroke: [1,"rgb(228, 228, 228)","solid"]
            },
            {
                id: 'title4',
                type: 'rect',
                rect: ['8', '212','auto','auto','auto', 'auto'],
                clip: ['rect(0px 182px 24px 0px)']
            },
            {
                id: 'Text4Copy29',
                type: 'text',
                rect: ['460px', '229px','83px','13px','auto', 'auto'],
                cursor: ['pointer'],
                text: "المشورات الخاصة",
                align: "right",
                font: ['Arial, Helvetica, sans-serif', 14, "rgba(21,21,21,1.00)", "900", "underline", "normal"]
            },
            {
                id: 'pramed',
                type: 'image',
                rect: ['370px', '158px','483px','487px','auto', 'auto'],
                clip: ['rect(0px 483px 487px 0px)'],
                fill: ["rgba(0,0,0,0)",im+"pramed.png",'0px','0px']
            }],
            symbolInstances: [
            {
                id: 'title4',
                symbolName: 'title4'
            },
            {
                id: 'title1',
                symbolName: 'title1',
                autoPlay: {

                }
            },
            {
                id: 'Symbol_1',
                symbolName: 'Symbol_1'
            },
            {
                id: 'title2',
                symbolName: 'title2',
                autoPlay: {

                }
            }
            ]
        },
    states: {
        "Base State": {
            "${_Text4Copy28}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '700'],
                ["style", "left", '330px'],
                ["style", "width", '63px'],
                ["style", "top", '60px'],
                ["style", "font-size", '12px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy3}": [
                ["color", "color", 'rgba(21,21,21,1.00)'],
                ["style", "font-weight", '900'],
                ["style", "cursor", 'pointer'],
                ["style", "font-size", '14px'],
                ["style", "top", '32px'],
                ["style", "left", '0px'],
                ["style", "height", '13px'],
                ["style", "width", '109px'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy13}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '235px'],
                ["style", "width", '108px'],
                ["style", "top", '55px'],
                ["style", "opacity", '0'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "font-size", '14px']
            ],
            "${_pramed}": [
                ["style", "top", '158px'],
                ["style", "left", '370px'],
                ["style", "clip", [491,483,487,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ]
            ],
            "${_Text4Copy20}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '219px'],
                ["style", "width", '37px'],
                ["style", "top", '84px'],
                ["style", "font-size", '14px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Rectangle4}": [
                ["style", "top", '0px'],
                ["style", "left", '14px'],
                ["style", "clip", [0,494,108,494], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["style", "height", '108px']
            ],
            "${_Text4}": [
                ["color", "color", 'rgba(21,21,21,1.00)'],
                ["style", "font-weight", '900'],
                ["style", "left", '298px'],
                ["style", "width", '92px'],
                ["style", "top", '32px'],
                ["style", "font-size", '14px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy8}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '267px'],
                ["style", "width", '79px'],
                ["style", "top", '27px'],
                ["style", "font-size", '14px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy23}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '322px'],
                ["style", "width", '64px'],
                ["style", "top", '31px'],
                ["style", "opacity", '0.01'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "font-size", '14px']
            ],
            "${_Text4Copy9}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '182px'],
                ["style", "width", '79px'],
                ["style", "top", '27px'],
                ["style", "opacity", '0'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "font-size", '14px']
            ],
            "${_Text4Copy27}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '700'],
                ["style", "left", '432px'],
                ["style", "width", '40px'],
                ["style", "top", '60px'],
                ["style", "opacity", '0'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "font-size", '12px']
            ],
            "${_Text4Copy17}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '261px'],
                ["style", "width", '79px'],
                ["style", "top", '84px'],
                ["style", "opacity", '0'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "font-size", '14px']
            ],
            "${_Text4Copy25}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '229px'],
                ["style", "width", '69px'],
                ["style", "top", '31px'],
                ["style", "opacity", '0'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "font-size", '14px']
            ],
            "${_Text4Copy16}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '347px'],
                ["style", "width", '79px'],
                ["style", "top", '84px'],
                ["style", "font-size", '14px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy2}": [
                ["color", "color", 'rgba(21,21,21,1.00)'],
                ["style", "font-weight", '900'],
                ["style", "left", '104px'],
                ["style", "width", '109px'],
                ["style", "top", '32px'],
                ["style", "font-size", '14px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy26}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '30px'],
                ["style", "width", '69px'],
                ["style", "top", '31px'],
                ["style", "font-size", '14px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy21}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '4px'],
                ["style", "width", '108px'],
                ["style", "top", '84px'],
                ["style", "font-size", '12px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy11}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '178px'],
                ["style", "width", '54px'],
                ["style", "top", '55px'],
                ["style", "opacity", '0'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "font-size", '14px']
            ],
            "${_Text4Copy6}": [
                ["color", "color", 'rgba(21,21,21,1.00)'],
                ["style", "font-weight", '900'],
                ["style", "cursor", 'pointer'],
                ["style", "font-size", '14px'],
                ["style", "top", '63px'],
                ["style", "left", '119px'],
                ["style", "height", '13px'],
                ["style", "width", '92px'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_PRAMID-SERVICES3_01}": [
                ["style", "top", '-1px'],
                ["style", "opacity", '0.000000'],
                ["style", "left", '0px'],
                ["style", "width", '850px']
            ],
            "${_Text4Copy29}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '460px'],
                ["style", "width", '83px'],
                ["style", "top", '229px'],
                ["style", "font-size", '14px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_title4}": [
                ["style", "clip", [0,0,24,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ]
            ],
            "${_Text4Copy5}": [
                ["color", "color", 'rgba(21,21,21,1.00)'],
                ["style", "font-weight", '900'],
                ["style", "left", '204px'],
                ["style", "width", '92px'],
                ["style", "top", '63px'],
                ["style", "cursor", 'pointer'],
                ["style", "height", '13px'],
                ["style", "font-size", '14px'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy18}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '0px'],
                ["style", "width", '79px'],
                ["style", "top", '55px'],
                ["style", "font-size", '14px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy24}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '136px'],
                ["style", "width", '69px'],
                ["style", "top", '31px'],
                ["style", "font-size", '14px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Rectangle}": [
                ["color", "background-color", 'rgba(255,255,255,1.00)'],
                ["subproperty", "boxShadow.blur", '5px'],
                ["style", "border-style", 'solid'],
                ["style", "border-width", '1px'],
                ["style", "top", '0px'],
                ["subproperty", "boxShadow.offsetV", '1px'],
                ["subproperty", "boxShadow.offsetH", '3px'],
                ["subproperty", "boxShadow.color", 'rgba(0,0,0,0.65098)'],
                ["color", "border-color", 'rgba(215,214,214,1.00)'],
                ["style", "clip", [0,430.19970703125,116.7998046875,429.7998046875], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["style", "left", '19px']
            ],
            "${_Rectangle7}": [
                ["style", "height", '86px'],
                ["style", "clip", [0,587,86,588.5], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["style", "top", '208px']
            ],
            "${_Text4Copy10}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '91px'],
                ["style", "width", '83px'],
                ["style", "top", '27px'],
                ["style", "font-size", '14px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy15}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '91px'],
                ["style", "width", '79px'],
                ["style", "top", '55px'],
                ["style", "opacity", '0'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "font-size", '14px']
            ],
            "${_Text4Copy}": [
                ["color", "color", 'rgba(21,21,21,1.00)'],
                ["style", "font-weight", '900'],
                ["style", "left", '201px'],
                ["style", "font-size", '14px'],
                ["style", "top", '32px'],
                ["style", "width", '92px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy14}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '18px'],
                ["style", "width", '65px'],
                ["style", "top", '27px'],
                ["style", "font-size", '14px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Rectangle5}": [
                ["style", "top", '0px'],
                ["style", "clip", [0,535,97,536], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["color", "background-color", 'rgba(255,255,255,1.00)'],
                ["style", "left", '5px'],
                ["style", "width", '535px']
            ],
            "${_Text4Copy19}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '124px'],
                ["style", "width", '79px'],
                ["style", "top", '84px'],
                ["style", "opacity", '0'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "font-size", '14px']
            ],
            "${_Symbol_1}": [
                ["style", "top", '4px'],
                ["style", "left", '0px'],
                ["style", "clip", [0,-31,24,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ]
            ],
            "${_title1}": [
                ["style", "top", '4px'],
                ["style", "left", '14px'],
                ["style", "clip", [0,-7.19970703125,23,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ]
            ],
            "${_Text4Copy12}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '349px'],
                ["style", "width", '92px'],
                ["style", "top", '55px'],
                ["style", "font-size", '14px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Stage}": [
                ["color", "background-color", 'rgba(235,235,235,1.00)'],
                ["style", "overflow", 'hidden'],
                ["style", "height", '650px'],
                ["gradient", "background-image", [270,[['rgba(255,255,255,0.00)',0],['rgba(255,255,255,0.00)',100]]]],
                ["style", "width", '850px']
            ],
            "${_Text4Copy4}": [
                ["color", "color", 'rgba(21,21,21,1.00)'],
                ["style", "font-weight", '900'],
                ["style", "cursor", 'pointer'],
                ["style", "font-size", '14px'],
                ["style", "top", '63px'],
                ["style", "left", '294px'],
                ["style", "height", '13px'],
                ["style", "width", '92px'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy22}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '417px'],
                ["style", "width", '64px'],
                ["style", "top", '31px'],
                ["style", "font-size", '14px'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "opacity", '0']
            ],
            "${_Text4Copy7}": [
                ["color", "color", 'rgba(21,21,21,1)'],
                ["style", "font-weight", '900'],
                ["style", "left", '349px'],
                ["style", "width", '104px'],
                ["style", "top", '27px'],
                ["style", "opacity", '0'],
                ["style", "height", '13px'],
                ["style", "cursor", 'pointer'],
                ["style", "text-decoration", 'underline'],
                ["style", "font-size", '14px']
            ],
            "${_title2}": [
                ["style", "top", '3px'],
                ["style", "left", '9px'],
                ["style", "clip", [0,0,24,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ]
            ]
        }
    },
    timelines: {
        "Default Timeline": {
            fromState: "Base State",
            toState: "",
            duration: 10427,
            autoPlay: true,
            timeline: [
                { id: "eid142", tween: [ "style", "${_Text4Copy21}", "opacity", '1', { fromValue: '0'}], position: 7440, duration: 137 },
                { id: "eid166", tween: [ "style", "${_Symbol_1}", "clip", [0,182,24,0], { valueTemplate: 'rect(@@0@@px @@1@@px @@2@@px @@3@@px)', fromValue: [0,-31,24,0]}], position: 8089, duration: 411 },
                { id: "eid206", tween: [ "style", "${_Text4Copy29}", "opacity", '1', { fromValue: '0'}], position: 10250, duration: 177 },
                { id: "eid171", tween: [ "style", "${_Text4Copy22}", "opacity", '1', { fromValue: '0'}], position: 8500, duration: 112 },
                { id: "eid97", tween: [ "style", "${_title2}", "clip", [0,182,24,0], { valueTemplate: 'rect(@@0@@px @@1@@px @@2@@px @@3@@px)', fromValue: [0,0,24,0]}], position: 5205, duration: 501 },
                { id: "eid127", tween: [ "style", "${_Text4Copy18}", "opacity", '1', { fromValue: '0'}], position: 6816, duration: 133 },
                { id: "eid59", tween: [ "style", "${_Text4Copy4}", "opacity", '1', { fromValue: '0'}], position: 4070, duration: 180 },
                { id: "eid186", tween: [ "style", "${_Text4Copy27}", "opacity", '1', { fromValue: '0'}], position: 9038, duration: 121 },
                { id: "eid22", tween: [ "style", "${_Rectangle}", "clip", [0,429.39990234375,117.99951171875,-1], { valueTemplate: 'rect(@@0@@px @@1@@px @@2@@px @@3@@px)', fromValue: [0,430.19970703125,116.7998046875,429.7998046875]}], position: 2195, duration: 635 },
                { id: "eid130", tween: [ "style", "${_Text4Copy16}", "opacity", '1', { fromValue: '0'}], position: 6949, duration: 121 },
                { id: "eid6", tween: [ "color", "${_Stage}", "background-color", 'rgba(235,235,235,1.00)', { animationColorSpace: 'RGB', valueTemplate: undefined, fromValue: 'rgba(235,235,235,1.00)'}], position: 0, duration: 0 },
                { id: "eid112", tween: [ "style", "${_Text4Copy14}", "opacity", '1', { fromValue: '0'}], position: 6250, duration: 121 },
                { id: "eid115", tween: [ "style", "${_Text4Copy12}", "opacity", '1', { fromValue: '0'}], position: 6371, duration: 129 },
                { id: "eid53", tween: [ "style", "${_Text4Copy2}", "opacity", '1', { fromValue: '0'}], position: 3750, duration: 160 },
                { id: "eid92", tween: [ "style", "${_Rectangle4}", "clip", [0,497.3330078125,111.33349609375,0], { valueTemplate: 'rect(@@0@@px @@1@@px @@2@@px @@3@@px)', fromValue: [0,494,108,494]}], position: 4600, duration: 605 },
                { id: "eid177", tween: [ "style", "${_Text4Copy25}", "opacity", '1', { fromValue: '0'}], position: 8713, duration: 117 },
                { id: "eid62", tween: [ "style", "${_Text4Copy3}", "opacity", '1', { fromValue: '0'}], position: 3910, duration: 160 },
                { id: "eid17", tween: [ "style", "${_pramed}", "clip", [1,483,487,0], { valueTemplate: 'rect(@@0@@px @@1@@px @@2@@px @@3@@px)', fromValue: [491,483,487,0]}], position: 675, duration: 1520 },
                { id: "eid109", tween: [ "style", "${_Text4Copy10}", "opacity", '1', { fromValue: '0'}], position: 6104, duration: 146 },
                { id: "eid106", tween: [ "style", "${_Text4Copy9}", "opacity", '1', { fromValue: '0'}], position: 5971, duration: 133 },
                { id: "eid192", tween: [ "style", "${_Rectangle7}", "clip", [0,587,86,0], { valueTemplate: 'rect(@@0@@px @@1@@px @@2@@px @@3@@px)', fromValue: [0,587,86,588.5]}], position: 9290, duration: 519 },
                { id: "eid183", tween: [ "style", "${_Text4Copy26}", "opacity", '1', { fromValue: '0'}], position: 8928, duration: 110 },
                { id: "eid121", tween: [ "style", "${_Text4Copy11}", "opacity", '1', { fromValue: '0'}], position: 6602, duration: 102 },
                { id: "eid68", tween: [ "style", "${_Text4Copy6}", "opacity", '1', { fromValue: '0'}], position: 4420, duration: 180 },
                { id: "eid189", tween: [ "style", "${_Text4Copy28}", "opacity", '1', { fromValue: '0'}], position: 9159, duration: 131 },
                { id: "eid34", tween: [ "style", "${_title1}", "clip", [0,184.00048828125,23,0], { valueTemplate: 'rect(@@0@@px @@1@@px @@2@@px @@3@@px)', fromValue: [0,-7.19970703125,23,0]}], position: 2830, duration: 620 },
                { id: "eid10", tween: [ "style", "${_PRAMID-SERVICES3_01}", "opacity", '1', { fromValue: '0.000000'}], position: 0, duration: 675 },
                { id: "eid201", tween: [ "style", "${_title4}", "clip", [0,187,24,0], { valueTemplate: 'rect(@@0@@px @@1@@px @@2@@px @@3@@px)', fromValue: [0,0,24,0]}], position: 9876, duration: 374 },
                { id: "eid163", tween: [ "style", "${_Rectangle5}", "clip", [0,535,97,0], { valueTemplate: 'rect(@@0@@px @@1@@px @@2@@px @@3@@px)', fromValue: [0,535,97,536]}], position: 7577, duration: 512 },
                { id: "eid2", tween: [ "gradient", "${_Stage}", "background-image", [270,[['rgba(255,255,255,0.00)',0],['rgba(255,255,255,0.00)',100]]], { fromValue: [270,[['rgba(255,255,255,0.00)',0],['rgba(255,255,255,0.00)',100]]]}], position: 0, duration: 0 },
                { id: "eid180", tween: [ "style", "${_Text4Copy24}", "opacity", '1', { fromValue: '0'}], position: 8830, duration: 98 },
                { id: "eid118", tween: [ "style", "${_Text4Copy13}", "opacity", '1', { fromValue: '0'}], position: 6500, duration: 102 },
                { id: "eid139", tween: [ "style", "${_Text4Copy19}", "opacity", '1', { fromValue: '0'}], position: 7323, duration: 117 },
                { id: "eid124", tween: [ "style", "${_Text4Copy15}", "opacity", '1', { fromValue: '0'}], position: 6704, duration: 112 },
                { id: "eid65", tween: [ "style", "${_Text4Copy5}", "opacity", '1', { fromValue: '0'}], position: 4250, duration: 170 },
                { id: "eid136", tween: [ "style", "${_Text4Copy20}", "opacity", '1', { fromValue: '0'}], position: 7183, duration: 140 },
                { id: "eid47", tween: [ "style", "${_Text4}", "opacity", '1', { fromValue: '0'}], position: 3450, duration: 150 },
                { id: "eid100", tween: [ "style", "${_Text4Copy7}", "opacity", '1', { fromValue: '0'}], position: 5706, duration: 133 },
                { id: "eid103", tween: [ "style", "${_Text4Copy8}", "opacity", '1', { fromValue: '0'}], position: 5839, duration: 132 },
                { id: "eid133", tween: [ "style", "${_Text4Copy17}", "opacity", '1', { fromValue: '0'}], position: 7070, duration: 113 },
                { id: "eid50", tween: [ "style", "${_Text4Copy}", "opacity", '1', { fromValue: '0'}], position: 3600, duration: 150 },
                { id: "eid174", tween: [ "style", "${_Text4Copy23}", "opacity", '1', { fromValue: '0.01'}], position: 8612, duration: 101 },
                { id: "eid35", trigger: [ function executeSymbolFunction(e, data) { this._executeSymbolAction(e, data); }, ['stop', '${_title1}', [] ], ""], position: 0 },
                { id: "eid167", trigger: [ function executeSymbolFunction(e, data) { this._executeSymbolAction(e, data); }, ['stop', '${_Symbol_1}', [] ], ""], position: 0 },
                { id: "eid202", trigger: [ function executeSymbolFunction(e, data) { this._executeSymbolAction(e, data); }, ['stop', '${_title4}', [] ], ""], position: 0 },
                { id: "eid95", trigger: [ function executeSymbolFunction(e, data) { this._executeSymbolAction(e, data); }, ['stop', '${_title2}', [] ], ""], position: 0 },
                { id: "eid36", trigger: [ function executeSymbolFunction(e, data) { this._executeSymbolAction(e, data); }, ['play', '${_title1}', [] ], ""], position: 2830 },
                { id: "eid96", trigger: [ function executeSymbolFunction(e, data) { this._executeSymbolAction(e, data); }, ['play', '${_title2}', [] ], ""], position: 5205 },
                { id: "eid168", trigger: [ function executeSymbolFunction(e, data) { this._executeSymbolAction(e, data); }, ['play', '${_Symbol_1}', [] ], ""], position: 8089 },
                { id: "eid203", trigger: [ function executeSymbolFunction(e, data) { this._executeSymbolAction(e, data); }, ['play', '${_title4}', [] ], ""], position: 9814 }            ]
        }
    }
},
"title1": {
    version: "4.0.0",
    minimumCompatibleVersion: "4.0.0",
    build: "4.0.0.359",
    baseState: "Base State",
    scaleToFit: "none",
    centerStage: "none",
    initialState: "Base State",
    gpuAccelerate: false,
    resizeInstances: false,
    content: {
            dom: [
                {
                    type: 'rect',
                    rect: ['5px', '0px', '177px', '18px', 'auto', 'auto'],
                    id: 'title',
                    stroke: [1, 'rgb(228, 228, 228)', 'solid'],
                    clip: ['rect(0px 177px 18px 0px)'],
                    fill: ['rgba(71,184,28,1.00)']
                },
                {
                    type: 'ellipse',
                    borderRadius: ['50%', '50%', '50%', '50%'],
                    rect: ['0px', '0px', '20px', '18px', 'auto', 'auto'],
                    id: 'Ellipse',
                    stroke: [1, 'rgb(228, 228, 228)', 'solid'],
                    clip: ['rect(-0.800048828125px 22.39990234375px 22.800048828125px -0.39990234375px)'],
                    fill: ['rgba(104,225,59,1.00)', [270, [['rgba(208,208,208,1.00)', 0], ['rgba(39,39,39,1.00)', 100]]]]
                },
                {
                    font: ['Arial, Helvetica, sans-serif', 10, 'rgba(255,255,255,1.00)', '600', 'none', ''],
                    type: 'text',
                    id: 'Text',
                    text: 'BC',
                    clip: ['rect(0px 16px 20px 0px)'],
                    rect: ['4px', '4px', '16px', '20px', 'auto', 'auto']
                },
                {
                    font: ['Arial, Helvetica, sans-serif', 13, 'rgba(255,255,255,1)', '800', 'none', 'normal'],
                    type: 'text',
                    align: 'left',
                    id: 'Text2',
                    text: 'المبتدئ - المتدرب - الطالب',
                    clip: ['rect(0px 142px 20px 0px)'],
                    rect: ['33px', '0px', '142px', '20px', 'auto', 'auto']
                }
            ],
            symbolInstances: [
            ]
        },
    states: {
        "Base State": {
            "${_Text}": [
                ["style", "top", '4px'],
                ["style", "font-size", '10px'],
                ["style", "left", '4px'],
                ["color", "color", 'rgba(255,255,255,1.00)'],
                ["style", "font-weight", '600'],
                ["style", "clip", [0,16,20,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["style", "width", '16px']
            ],
            "${symbolSelector}": [
                ["style", "height", '23px'],
                ["style", "width", '184px']
            ],
            "${_Ellipse}": [
                ["style", "top", '0px'],
                ["color", "background-color", 'rgba(104,225,59,1.00)'],
                ["gradient", "background-image", [270,[['rgba(208,208,208,1.00)',0],['rgba(39,39,39,1.00)',100]]]],
                ["style", "left", '0px'],
                ["style", "clip", [-0.800048828125,22.39990234375,22.800048828125,-0.39990234375], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ]
            ],
            "${_Text2}": [
                ["style", "top", '0px'],
                ["style", "clip", [0,142,20,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["style", "font-weight", '800'],
                ["style", "left", '33px'],
                ["style", "font-size", '13px']
            ],
            "${_title}": [
                ["color", "background-color", 'rgba(71,184,28,1.00)'],
                ["style", "top", '0px'],
                ["style", "clip", [0,177,18,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["style", "left", '5px']
            ]
        }
    },
    timelines: {
        "Default Timeline": {
            fromState: "Base State",
            toState: "",
            duration: 0,
            autoPlay: true,
            timeline: [
            ]
        }
    }
},
"title2": {
    version: "4.0.0",
    minimumCompatibleVersion: "4.0.0",
    build: "4.0.0.359",
    baseState: "Base State",
    scaleToFit: "none",
    centerStage: "none",
    initialState: "Base State",
    gpuAccelerate: false,
    resizeInstances: false,
    content: {
            dom: [
                {
                    rect: ['5px', '1px', '175px', '17px', 'auto', 'auto'],
                    id: 'Rectangle5',
                    stroke: [1, 'rgb(215, 214, 214)', 'solid'],
                    type: 'rect',
                    fill: ['rgba(0,193,228,1.00)']
                },
                {
                    rect: ['-8px', '-406px', '20px', '18px', 'auto', 'auto'],
                    borderRadius: ['50%', '50%', '50%', '50%'],
                    type: 'ellipse',
                    id: 'Ellipse',
                    stroke: [1, 'rgb(228, 228, 228)', 'solid'],
                    clip: ['rect(-0.800048828125px 22.39990234375px 22.800048828125px -0.39990234375px)'],
                    fill: ['rgba(104,225,59,1.00)', [270, [['rgba(208,208,208,1.00)', 0], ['rgba(39,39,39,1.00)', 100]]]]
                },
                {
                    rect: ['29px', '1px', '142px', '20px', 'auto', 'auto'],
                    font: ['Arial, Helvetica, sans-serif', 13, 'rgba(255,255,255,1)', '800', 'none', 'normal'],
                    align: 'left',
                    id: 'Text2',
                    text: 'المحلل - المستثمر - المضارب ',
                    clip: ['rect(0px 142px 20px 0px)'],
                    type: 'text'
                },
                {
                    rect: ['-4px', '-402px', '16px', '20px', 'auto', 'auto'],
                    font: ['Arial, Helvetica, sans-serif', 10, 'rgba(255,255,255,1.00)', '600', 'none', ''],
                    id: 'Text',
                    text: 'BC',
                    clip: ['rect(0px 16px 20px 0px)'],
                    type: 'text'
                }
            ],
            symbolInstances: [
            ]
        },
    states: {
        "Base State": {
            "${_Ellipse}": [
                ["style", "top", '0px'],
                ["color", "background-color", 'rgba(104,225,59,1.00)'],
                ["gradient", "background-image", [270,[['rgba(208,208,208,1.00)',0],['rgba(39,39,39,1.00)',100]]]],
                ["style", "left", '0px'],
                ["style", "clip", [-0.800048828125,22.39990234375,22.800048828125,-0.39990234375], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ]
            ],
            "${symbolSelector}": [
                ["style", "height", '24px'],
                ["style", "width", '182px']
            ],
            "${_Rectangle5}": [
                ["color", "background-color", 'rgba(0,193,228,1.00)'],
                ["style", "height", '17px'],
                ["style", "top", '1px'],
                ["style", "left", '5px'],
                ["style", "width", '175px']
            ],
            "${_Text2}": [
                ["style", "top", '1px'],
                ["style", "clip", [0,142,20,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["style", "font-weight", '800'],
                ["style", "left", '29px'],
                ["style", "font-size", '13px']
            ],
            "${_Text}": [
                ["style", "top", '4px'],
                ["style", "font-size", '10px'],
                ["style", "left", '3px'],
                ["color", "color", 'rgba(255,255,255,1.00)'],
                ["style", "font-weight", '600'],
                ["style", "clip", [0,16,20,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["style", "width", '16px']
            ]
        }
    },
    timelines: {
        "Default Timeline": {
            fromState: "Base State",
            toState: "",
            duration: 0,
            autoPlay: true,
            timeline: [
            ]
        }
    }
},
"Symbol_1": {
    version: "4.0.0",
    minimumCompatibleVersion: "4.0.0",
    build: "4.0.0.359",
    baseState: "Base State",
    scaleToFit: "none",
    centerStage: "none",
    initialState: "Base State",
    gpuAccelerate: false,
    resizeInstances: false,
    content: {
            dom: [
                {
                    rect: ['5px', '1px', '175px', '17px', 'auto', 'auto'],
                    id: 'Rectangle6',
                    stroke: [1, 'rgb(228, 228, 228)', 'solid'],
                    type: 'rect',
                    fill: ['rgba(227,219,9,1.00)']
                },
                {
                    rect: ['0px', '0px', '20px', '18px', 'auto', 'auto'],
                    borderRadius: ['50%', '50%', '50%', '50%'],
                    type: 'ellipse',
                    id: 'Ellipse',
                    stroke: [1, 'rgb(228, 228, 228)', 'solid'],
                    clip: ['rect(-0.800048828125px 22.39990234375px 22.800048828125px -0.39990234375px)'],
                    fill: ['rgba(104,225,59,1.00)', [270, [['rgba(208,208,208,1.00)', 0], ['rgba(39,39,39,1.00)', 100]]]]
                },
                {
                    rect: ['3px', '4px', '16px', '20px', 'auto', 'auto'],
                    font: ['Arial, Helvetica, sans-serif', 10, 'rgba(255,255,255,1.00)', '600', 'none', ''],
                    id: 'Text',
                    text: 'BC',
                    clip: ['rect(0px 16px 20px 0px)'],
                    type: 'text'
                },
                {
                    rect: ['30px', '1px', '142px', '20px', 'auto', 'auto'],
                    font: ['Arial, Helvetica, sans-serif', 13, 'rgba(255,255,255,1)', '800', 'none', 'normal'],
                    align: 'left',
                    id: 'Text2',
                    text: 'الشركات الخاصة',
                    clip: ['rect(0px 142px 20px 0px)'],
                    type: 'text'
                }
            ],
            symbolInstances: [
            ]
        },
    states: {
        "Base State": {
            "${_Ellipse}": [
                ["style", "top", '0px'],
                ["style", "clip", [-0.800048828125,22.39990234375,22.800048828125,-0.39990234375], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["gradient", "background-image", [270,[['rgba(208,208,208,1.00)',0],['rgba(39,39,39,1.00)',100]]]],
                ["style", "left", '0px'],
                ["color", "background-color", 'rgba(104,225,59,1)']
            ],
            "${symbolSelector}": [
                ["style", "height", '24px'],
                ["style", "width", '182px']
            ],
            "${_Text}": [
                ["style", "top", '4px'],
                ["style", "width", '16px'],
                ["transform", "scaleY", '1'],
                ["style", "clip", [0,16,20,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["color", "color", 'rgba(255,255,255,1)'],
                ["style", "font-weight", '600'],
                ["style", "left", '3px'],
                ["style", "font-size", '10px']
            ],
            "${_Text2}": [
                ["style", "top", '1px'],
                ["style", "clip", [0,142,20,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["style", "font-weight", '800'],
                ["style", "left", '30px'],
                ["style", "font-size", '13px']
            ],
            "${_Rectangle6}": [
                ["color", "background-color", 'rgba(227,219,9,1.00)'],
                ["style", "height", '17px'],
                ["style", "top", '1px'],
                ["style", "left", '5px'],
                ["style", "width", '175px']
            ]
        }
    },
    timelines: {
        "Default Timeline": {
            fromState: "Base State",
            toState: "",
            duration: 0,
            autoPlay: true,
            timeline: [
            ]
        }
    }
},
"title4": {
    version: "4.0.0",
    minimumCompatibleVersion: "4.0.0",
    build: "4.0.0.359",
    baseState: "Base State",
    scaleToFit: "none",
    centerStage: "none",
    initialState: "Base State",
    gpuAccelerate: false,
    resizeInstances: false,
    content: {
            dom: [
                {
                    rect: ['5px', '1px', '175px', '17px', 'auto', 'auto'],
                    id: 'Rectangle8',
                    stroke: [1, 'rgb(228, 228, 228)', 'solid'],
                    type: 'rect',
                    fill: ['rgba(15,83,255,1.00)']
                },
                {
                    rect: ['0px', '0px', '20px', '18px', 'auto', 'auto'],
                    borderRadius: ['50%', '50%', '50%', '50%'],
                    type: 'ellipse',
                    id: 'EllipseCopy',
                    stroke: [1, 'rgb(228, 228, 228)', 'solid'],
                    clip: ['rect(-0.800048828125px 22.39990234375px 22.800048828125px -0.39990234375px)'],
                    fill: ['rgba(104,225,59,1.00)', [270, [['rgba(208,208,208,1.00)', 0], ['rgba(39,39,39,1.00)', 100]]]]
                },
                {
                    rect: ['32px', '1px', '142px', '20px', 'auto', 'auto'],
                    font: ['Arial, Helvetica, sans-serif', 13, 'rgba(255,255,255,1)', '800', 'none', 'normal'],
                    align: 'left',
                    id: 'Text2Copy',
                    text: 'بـورصة بـــرو',
                    clip: ['rect(0px 142px 20px 0px)'],
                    type: 'text'
                },
                {
                    rect: ['3px', '4px', '16px', '20px', 'auto', 'auto'],
                    font: ['Arial, Helvetica, sans-serif', 10, 'rgba(255,255,255,1.00)', '600', 'none', ''],
                    id: 'TextCopy',
                    text: 'BC',
                    clip: ['rect(0px 16px 20px 0px)'],
                    type: 'text'
                }
            ],
            symbolInstances: [
            ]
        },
    states: {
        "Base State": {
            "${_Text2Copy}": [
                ["style", "top", '1px'],
                ["style", "left", '32px'],
                ["transform", "scaleX", '1'],
                ["style", "font-weight", '800'],
                ["style", "clip", [0,142,20,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["style", "font-size", '13px']
            ],
            "${symbolSelector}": [
                ["style", "height", '24px'],
                ["style", "width", '182px']
            ],
            "${_EllipseCopy}": [
                ["style", "top", '0px'],
                ["style", "clip", [-0.800048828125,22.39990234375,22.800048828125,-0.39990234375], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["gradient", "background-image", [270,[['rgba(208,208,208,1.00)',0],['rgba(39,39,39,1.00)',100]]]],
                ["style", "left", '0px'],
                ["color", "background-color", 'rgba(104,225,59,1)']
            ],
            "${_TextCopy}": [
                ["style", "top", '4px'],
                ["style", "width", '16px'],
                ["transform", "scaleY", '1'],
                ["style", "clip", [0,16,20,0], {valueTemplate:'rect(@@0@@px @@1@@px @@2@@px @@3@@px)'} ],
                ["color", "color", 'rgba(255,255,255,1)'],
                ["style", "font-weight", '600'],
                ["style", "left", '3px'],
                ["style", "font-size", '10px']
            ],
            "${_Rectangle8}": [
                ["style", "top", '1px'],
                ["style", "height", '17px'],
                ["color", "background-color", 'rgba(15,83,255,1.00)'],
                ["style", "left", '5px'],
                ["style", "width", '175px']
            ]
        }
    },
    timelines: {
        "Default Timeline": {
            fromState: "Base State",
            toState: "",
            duration: 0,
            autoPlay: true,
            timeline: [
            ]
        }
    }
}
};


Edge.registerCompositionDefn(compId, symbols, fonts, resources, opts);

/**
 * Adobe Edge DOM Ready Event Handler
 */
$(window).ready(function() {
     Edge.launchComposition(compId);
});
})(jQuery, AdobeEdge, "EDGE-1150730");
