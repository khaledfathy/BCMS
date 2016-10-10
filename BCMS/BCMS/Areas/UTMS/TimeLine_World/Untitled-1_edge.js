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
                            rect: ['9px', '252px', '0', '3px', 'auto', 'auto'],
                            fill: ["rgba(192,192,192,1)"],
                            stroke: [0,"rgba(0,0,0,1)","none"]
                        },
                        {
                            id: 'acqezd8Ri2',
                            type: 'image',
                            rect: ['8', '235px', '85', '44', 'auto', 'auto'],
                            fill: ["rgba(0,0,0,0)",im+"acqezd8Ri.png",'0px','0px'],
                            transform: [[],[],[],[],['50%','51%']]
                        },
                        {
                            id: 'Group43',
                            type: 'group',
                            rect: ['0px', '105px', '71', '184', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy22',
                                type: 'rect',
                                rect: ['13', '126', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy45',
                                type: 'text',
                                rect: ['2', '170', 'auto', 'auto', 'auto', 'auto'],
                                text: "1790",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "700", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy44',
                                type: 'text',
                                rect: ['4px', '96px', 'auto', 'auto', 'auto', 'auto'],
                                text: "فيلادلفيا",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "700", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F16',
                                type: 'image',
                                rect: ['10px', '41px', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F1.png",'0px','0px']
                            },
                            {
                                id: 'EllipseCopy22',
                                type: 'ellipse',
                                rect: ['9', '143', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1.00)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            }]
                        },
                        {
                            id: 'Group42',
                            type: 'group',
                            rect: ['35', '105', '71', '184', 'auto', 'auto'],
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
                                text: "1792",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "700", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy2',
                                type: 'text',
                                rect: ['-15', '75', 'auto', 'auto', 'auto', 'auto'],
                                text: "نيويورك (NYSE)",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "700", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15',
                                type: 'image',
                                rect: ['31', '-25', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F1.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group41',
                            type: 'group',
                            rect: ['70', '138', '60', '151', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy',
                                type: 'rect',
                                rect: ['12', '93', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy',
                                type: 'ellipse',
                                rect: ['8', '110', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy5',
                                type: 'text',
                                rect: ['1', '137', 'auto', 'auto', 'auto', 'auto'],
                                text: "1801",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy4',
                                type: 'text',
                                rect: ['-5', '57', 'auto', 'auto', 'auto', 'auto'],
                                text: "لندن LSE",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy',
                                type: 'image',
                                rect: ['20', '-26', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F2.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group40',
                            type: 'group',
                            rect: ['105', '150', '51', '139', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy2',
                                type: 'rect',
                                rect: ['11', '81', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy2',
                                type: 'ellipse',
                                rect: ['7', '98', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy7',
                                type: 'text',
                                rect: ['0', '125', 'auto', 'auto', 'auto', 'auto'],
                                text: "1871",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy6',
                                type: 'text',
                                rect: ['-1', '51', 'auto', 'auto', 'auto', 'auto'],
                                text: "أسترالية",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy2',
                                type: 'image',
                                rect: ['11', '-26', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F3.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group39',
                            type: 'group',
                            rect: ['140', '160', '45', '129', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy3',
                                type: 'rect',
                                rect: ['11', '71', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy3',
                                type: 'ellipse',
                                rect: ['7', '88', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy9',
                                type: 'text',
                                rect: ['0', '115', 'auto', 'auto', 'auto', 'auto'],
                                text: "1878",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy8',
                                type: 'text',
                                rect: ['2', '44', 'auto', 'auto', 'auto', 'auto'],
                                text: "طوكيو",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy3',
                                type: 'image',
                                rect: ['5', '-26', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F4.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group38',
                            type: 'group',
                            rect: ['175', '105', '75', '184', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy4',
                                type: 'rect',
                                rect: ['11', '126', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy4',
                                type: 'ellipse',
                                rect: ['7', '143', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy11',
                                type: 'text',
                                rect: ['0', '170', 'auto', 'auto', 'auto', 'auto'],
                                text: "1883",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy10',
                                type: 'text',
                                rect: ['-18', '75', 'auto', 'auto', 'auto', 'auto'],
                                text: "القاهرة و الأسكندرية",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy4',
                                type: 'image',
                                rect: ['34', '-28', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F5.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group37',
                            type: 'group',
                            rect: ['210', '141', '58', '148', 'auto', 'auto'],
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
                                text: "1891",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy12',
                                type: 'text',
                                rect: ['-4', '53', 'auto', 'auto', 'auto', 'auto'],
                                text: "هونج كونج",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy5',
                                type: 'image',
                                rect: ['18', '-26', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F6.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group36',
                            type: 'group',
                            rect: ['245', '158', '48', '131', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy6',
                                type: 'rect',
                                rect: ['11', '73', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy6',
                                type: 'ellipse',
                                rect: ['7', '90', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy15',
                                type: 'text',
                                rect: ['0', '117', 'auto', 'auto', 'auto', 'auto'],
                                text: "1920",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy14',
                                type: 'text',
                                rect: ['1', '49', 'auto', 'auto', 'auto', 'auto'],
                                text: "بيروت",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy6',
                                type: 'image',
                                rect: ['7', '-23', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F7.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group35',
                            type: 'group',
                            rect: ['280', '129', '57', '160', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy7',
                                type: 'rect',
                                rect: ['11', '102', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy7',
                                type: 'ellipse',
                                rect: ['7', '119', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy17',
                                type: 'text',
                                rect: ['0', '146', 'auto', 'auto', 'auto', 'auto'],
                                text: "1929",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy16',
                                type: 'text',
                                rect: ['-8', '63', 'auto', 'auto', 'auto', 'auto'],
                                text: "الدار البيضاء",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy7',
                                type: 'image',
                                rect: ['14', '-24', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F8.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group34',
                            type: 'group',
                            rect: ['315', '154', '44', '135', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy8',
                                type: 'rect',
                                rect: ['11', '77', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy8',
                                type: 'ellipse',
                                rect: ['7', '94', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy19',
                                type: 'text',
                                rect: ['0', '121', 'auto', 'auto', 'auto', 'auto'],
                                text: "1969",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy18',
                                type: 'text',
                                rect: ['1', '52', 'auto', 'auto', 'auto', 'auto'],
                                text: "تونس",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy8',
                                type: 'image',
                                rect: ['3', '-20', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F9.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group33',
                            type: 'group',
                            rect: ['350', '159', '41', '130', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy9',
                                type: 'rect',
                                rect: ['11', '72', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy9',
                                type: 'ellipse',
                                rect: ['7', '89', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy21',
                                type: 'text',
                                rect: ['0', '116', 'auto', 'auto', 'auto', 'auto'],
                                text: "1976",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy20',
                                type: 'text',
                                rect: ['2', '47', 'auto', 'auto', 'auto', 'auto'],
                                text: "عمَان<br>",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy9',
                                type: 'image',
                                rect: ['0', '-23', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F10.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group32',
                            type: 'group',
                            rect: ['385', '149', '44', '140', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy10',
                                type: 'rect',
                                rect: ['11', '82', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy10',
                                type: 'ellipse',
                                rect: ['7', '99', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy23',
                                type: 'text',
                                rect: ['0', '126', 'auto', 'auto', 'auto', 'auto'],
                                text: "1977",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy22',
                                type: 'text',
                                rect: ['0', '55', 'auto', 'auto', 'auto', 'auto'],
                                text: "الكويت",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy10',
                                type: 'image',
                                rect: ['3', '-19', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F11.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group31',
                            type: 'group',
                            rect: ['420', '149', '48', '140', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy11',
                                type: 'rect',
                                rect: ['11', '82', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy11',
                                type: 'ellipse',
                                rect: ['7', '99', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy25',
                                type: 'text',
                                rect: ['0', '126', 'auto', 'auto', 'auto', 'auto'],
                                text: "1984",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy24',
                                type: 'text',
                                rect: ['-4', '53', 'auto', 'auto', 'auto', 'auto'],
                                text: "السعودية",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy11',
                                type: 'image',
                                rect: ['7', '-24', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F12.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group30',
                            type: 'group',
                            rect: ['455', '126', '61', '163', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy12',
                                type: 'rect',
                                rect: ['11', '105', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy12',
                                type: 'ellipse',
                                rect: ['7', '122', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy27',
                                type: 'text',
                                rect: ['0', '149', 'auto', 'auto', 'auto', 'auto'],
                                text: "1987",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy26',
                                type: 'text',
                                rect: ['-10', '62', 'auto', 'auto', 'auto', 'auto'],
                                text: "مملكة البحرين",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy12',
                                type: 'image',
                                rect: ['18', '-26', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F13.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group29',
                            type: 'group',
                            rect: ['490', '158', '44', '131', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy13',
                                type: 'rect',
                                rect: ['11', '73', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy13',
                                type: 'ellipse',
                                rect: ['7', '90', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy29',
                                type: 'text',
                                rect: ['0', '117', 'auto', 'auto', 'auto', 'auto'],
                                text: "1989",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy28',
                                type: 'text',
                                rect: ['2', '49', 'auto', 'auto', 'auto', 'auto'],
                                text: "مسقط",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy13',
                                type: 'image',
                                rect: ['4', '-22', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F14.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group28',
                            type: 'group',
                            rect: ['525', '98', '82', '191', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy14',
                                type: 'rect',
                                rect: ['11', '133', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy14',
                                type: 'ellipse',
                                rect: ['7', '150', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy31',
                                type: 'text',
                                rect: ['0', '177', 'auto', 'auto', 'auto', 'auto'],
                                text: "1992",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy30',
                                type: 'text',
                                rect: ['-22', '75', 'auto', 'auto', 'auto', 'auto'],
                                text: "الناسداك (Nasdaq)",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-64']]
                            },
                            {
                                id: 'F15Copy14',
                                type: 'image',
                                rect: ['31', '-30', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F15.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group27',
                            type: 'group',
                            rect: ['563', '163', '53', '126', 'auto', 'auto'],
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
                                text: "1995",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy32',
                                type: 'text',
                                rect: ['1', '44', 'auto', 'auto', 'auto', 'auto'],
                                text: "الدوحة",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy15',
                                type: 'image',
                                rect: ['3', '-30', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F16.png",'0px','0px'],
                                transform: [[],[],[],[],['55%']]
                            }]
                        },
                        {
                            id: 'Group26',
                            type: 'group',
                            rect: ['595', '150', '47', '139', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy16',
                                type: 'rect',
                                rect: ['11', '81', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy16',
                                type: 'ellipse',
                                rect: ['7', '98', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy35',
                                type: 'text',
                                rect: ['0', '125', 'auto', 'auto', 'auto', 'auto'],
                                text: "1995",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy34',
                                type: 'text',
                                rect: ['-1', '52', 'auto', 'auto', 'auto', 'auto'],
                                text: "فلسطين",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy16',
                                type: 'image',
                                rect: ['5', '-24', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F17.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group25',
                            type: 'group',
                            rect: ['630', '163', '40', '126', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy17',
                                type: 'rect',
                                rect: ['11', '68', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy17',
                                type: 'ellipse',
                                rect: ['7', '85', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy37',
                                type: 'text',
                                rect: ['0', '112', 'auto', 'auto', 'auto', 'auto'],
                                text: "2000",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy36',
                                type: 'text',
                                rect: ['3', '46', 'auto', 'auto', 'auto', 'auto'],
                                text: "دبى<br>",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy17',
                                type: 'image',
                                rect: ['-2', '-22', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F18.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group24',
                            type: 'group',
                            rect: ['665', '150', '47', '139', 'auto', 'auto'],
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy18',
                                type: 'rect',
                                rect: ['11', '81', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy18',
                                type: 'ellipse',
                                rect: ['7', '98', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy39',
                                type: 'text',
                                rect: ['0', '125', 'auto', 'auto', 'auto', 'auto'],
                                text: "2000",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy38',
                                type: 'text',
                                rect: ['-2', '52', 'auto', 'auto', 'auto', 'auto'],
                                text: "أبو ظبى",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy18',
                                type: 'image',
                                rect: ['3', '-26', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F19.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group23',
                            type: 'group',
                            rect: ['700', '154', '41', '135', 'auto', 'auto'],
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
                                text: "2004",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy40',
                                type: 'text',
                                rect: ['0', '50', 'auto', 'auto', 'auto', 'auto'],
                                text: "العراق",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy19',
                                type: 'image',
                                rect: ['1', '-26', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F20.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'Group22',
                            type: 'group',
                            rect: ['735', '163', '40', '126', 'auto', 'auto'],
                            cursor: 'pointer',
                            opacity: 0,
                            c: [
                            {
                                id: 'Rectangle2Copy20',
                                type: 'rect',
                                rect: ['16', '68', '2px', '44', 'auto', 'auto'],
                                fill: ["rgba(192,192,192,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'EllipseCopy20',
                                type: 'ellipse',
                                rect: ['12', '85', '10', '10', 'auto', 'auto'],
                                borderRadius: ["50%", "50%", "50%", "50%"],
                                fill: ["rgba(142,142,142,1)"],
                                stroke: [0,"rgb(0, 0, 0)","none"]
                            },
                            {
                                id: 'TextCopy43',
                                type: 'text',
                                rect: ['5', '112', 'auto', 'auto', 'auto', 'auto'],
                                text: "2008",
                                font: ['Arial, Helvetica, sans-serif', [11, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"]
                            },
                            {
                                id: 'TextCopy42',
                                type: 'text',
                                rect: ['7', '45', 'auto', 'auto', 'auto', 'auto'],
                                text: "ليبيا",
                                font: ['Arial, Helvetica, sans-serif', [14, "px"], "rgba(0,0,0,1)", "bold", "none", "", "break-word", "nowrap"],
                                transform: [[],['-59']]
                            },
                            {
                                id: 'F15Copy20',
                                type: 'image',
                                rect: ['0', '-26', '40', '40', 'auto', 'auto'],
                                fill: ["rgba(0,0,0,0)",im+"F21.png",'0px','0px']
                            }]
                        },
                        {
                            id: 'international',
                            symbolName: 'international',
                            type: 'rect',
                            rect: ['212px', '51px', '144', '39', 'auto', 'auto']
                        },
                        {
                            id: 'Arabic',
                            symbolName: 'Arabic',
                            type: 'rect',
                            rect: ['325px', '51px', '144', '39', 'auto', 'auto'],
                            cursor: 'pointer'
                        },
                        {
                            id: 'Gulf',
                            symbolName: 'Gulf',
                            type: 'rect',
                            rect: ['441px', '51px', '144', '39', 'auto', 'auto'],
                            cursor: 'pointer'
                        },
                        {
                            id: 'Text',
                            type: 'text',
                            rect: ['211px', '10px', '368px', '22px', 'auto', 'auto'],
                            text: "سنة تأسيس الاسواق المالية العالمية",
                            align: "center",
                            font: ['Arial, Helvetica, sans-serif', [30, "px"], "rgba(0,0,0,1.00)", "700", "none solid rgb(255, 255, 255)", "normal", "break-word", "normal"]
                        }
                    ],
                    style: {
                        '${Stage}': {
                            isStage: true,
                            rect: ['null', 'null', '850', '350px', 'auto', 'auto'],
                            overflow: 'hidden',
                            fill: ["rgba(255,255,255,1)"]
                        }
                    }
                },
                timeline: {
                    duration: 3626,
                    autoPlay: true,
                    data: [
                        [
                            "eid64",
                            "top",
                            3292,
                            167,
                            "easeInOutBounce",
                            "${F15Copy19}",
                            '-26px',
                            '0px'
                        ],
                        [
                            "eid62",
                            "top",
                            2958,
                            167,
                            "easeInOutBounce",
                            "${F15Copy17}",
                            '-22px',
                            '4px'
                        ],
                        [
                            "eid2",
                            "width",
                            0,
                            750,
                            "linear",
                            "${MainLine}",
                            '0px',
                            '171px'
                        ],
                        [
                            "eid82",
                            "width",
                            750,
                            2750,
                            "linear",
                            "${MainLine}",
                            '171px',
                            '755px'
                        ],
                        [
                            "eid65",
                            "top",
                            3459,
                            167,
                            "easeInOutBounce",
                            "${F15Copy20}",
                            '-26px',
                            '0px'
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
                            "eid63",
                            "top",
                            3125,
                            167,
                            "easeInOutBounce",
                            "${F15Copy18}",
                            '-26px',
                            '0px'
                        ],
                        [
                            "eid58",
                            "top",
                            2290,
                            167,
                            "easeInOutBounce",
                            "${F15Copy13}",
                            '-22px',
                            '4px'
                        ],
                        [
                            "eid60",
                            "top",
                            2624,
                            167,
                            "easeInOutBounce",
                            "${F15Copy15}",
                            '-30px',
                            '-4px'
                        ],
                        [
                            "eid33",
                            "opacity",
                            2123,
                            167,
                            "linear",
                            "${Group30}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid28",
                            "opacity",
                            1288,
                            167,
                            "linear",
                            "${Group35}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid37",
                            "opacity",
                            2791,
                            167,
                            "linear",
                            "${Group26}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid59",
                            "top",
                            2457,
                            167,
                            "easeInOutBounce",
                            "${F15Copy14}",
                            '-30px',
                            '-4px'
                        ],
                        [
                            "eid47",
                            "top",
                            453,
                            167,
                            "easeInOutBounce",
                            "${F15Copy2}",
                            '-26px',
                            '0px'
                        ],
                        [
                            "eid99",
                            "opacity",
                            0,
                            112,
                            "linear",
                            "${Group43}",
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
                            "eid80",
                            "left",
                            0,
                            194,
                            "linear",
                            "${acqezd8Ri2}",
                            '8px',
                            '44px'
                        ],
                        [
                            "eid100",
                            "left",
                            194,
                            3306,
                            "linear",
                            "${acqezd8Ri2}",
                            '44px',
                            '753px'
                        ],
                        [
                            "eid29",
                            "opacity",
                            1455,
                            167,
                            "linear",
                            "${Group34}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid24",
                            "opacity",
                            620,
                            167,
                            "linear",
                            "${Group39}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid50",
                            "top",
                            954,
                            167,
                            "easeInOutBounce",
                            "${F15Copy5}",
                            '-26px',
                            '0px'
                        ],
                        [
                            "eid30",
                            "opacity",
                            1622,
                            167,
                            "linear",
                            "${Group33}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid52",
                            "top",
                            1288,
                            167,
                            "easeInOutBounce",
                            "${F15Copy7}",
                            '-24px',
                            '2px'
                        ],
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
                            "eid49",
                            "top",
                            787,
                            167,
                            "easeInOutBounce",
                            "${F15Copy4}",
                            '-28px',
                            '-2px'
                        ],
                        [
                            "eid34",
                            "opacity",
                            2290,
                            167,
                            "linear",
                            "${Group29}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid53",
                            "top",
                            1455,
                            167,
                            "easeInOutBounce",
                            "${F15Copy8}",
                            '-20px',
                            '6px'
                        ],
                        [
                            "eid48",
                            "top",
                            620,
                            167,
                            "easeInOutBounce",
                            "${F15Copy3}",
                            '-26px',
                            '0px'
                        ],
                        [
                            "eid51",
                            "top",
                            1121,
                            167,
                            "easeInOutBounce",
                            "${F15Copy6}",
                            '-23px',
                            '3px'
                        ],
                        [
                            "eid57",
                            "top",
                            2123,
                            167,
                            "easeInOutBounce",
                            "${F15Copy12}",
                            '-26px',
                            '0px'
                        ],
                        [
                            "eid32",
                            "opacity",
                            1956,
                            167,
                            "linear",
                            "${Group31}",
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
                            "eid38",
                            "opacity",
                            2958,
                            167,
                            "linear",
                            "${Group25}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid23",
                            "opacity",
                            453,
                            167,
                            "linear",
                            "${Group40}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid61",
                            "top",
                            2791,
                            167,
                            "easeInOutBounce",
                            "${F15Copy16}",
                            '-24px',
                            '2px'
                        ],
                        [
                            "eid46",
                            "top",
                            286,
                            167,
                            "easeInOutBounce",
                            "${F15Copy}",
                            '-26px',
                            '0px'
                        ],
                        [
                            "eid39",
                            "opacity",
                            3125,
                            167,
                            "linear",
                            "${Group24}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid81",
                            "left",
                            750,
                            0,
                            "linear",
                            "${MainLine}",
                            '9px',
                            '9px'
                        ],
                        [
                            "eid27",
                            "opacity",
                            1121,
                            167,
                            "linear",
                            "${Group36}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid45",
                            "top",
                            0,
                            34,
                            "easeInBounce",
                            "${F15}",
                            '-25px',
                            '-22px'
                        ],
                        [
                            "eid83",
                            "top",
                            34,
                            252,
                            "easeOutBounce",
                            "${F15}",
                            '-22px',
                            '1px'
                        ],
                        [
                            "eid55",
                            "top",
                            1789,
                            167,
                            "easeInOutBounce",
                            "${F15Copy10}",
                            '-19px',
                            '7px'
                        ],
                        [
                            "eid22",
                            "opacity",
                            286,
                            167,
                            "linear",
                            "${Group41}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid56",
                            "top",
                            1956,
                            167,
                            "easeInOutBounce",
                            "${F15Copy11}",
                            '-24px',
                            '2px'
                        ],
                        [
                            "eid25",
                            "opacity",
                            787,
                            167,
                            "linear",
                            "${Group38}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid54",
                            "top",
                            1622,
                            167,
                            "easeInOutBounce",
                            "${F15Copy9}",
                            '-23px',
                            '3px'
                        ],
                        [
                            "eid41",
                            "opacity",
                            3459,
                            167,
                            "linear",
                            "${Group22}",
                            '0.000000',
                            '1'
                        ],
                        [
                            "eid35",
                            "opacity",
                            2457,
                            167,
                            "linear",
                            "${Group28}",
                            '0.000000',
                            '1'
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
                            rect: [12, 126, '2px', 44, 'auto', 'auto'],
                            id: 'Rectangle2',
                            stroke: [0, 'rgb(0, 0, 0)', 'none'],
                            type: 'rect',
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
                            font: ['Arial, Helvetica, sans-serif', [11, 'px'], 'rgba(0,0,0,1)', '700', 'none', '', '', 'nowrap'],
                            id: 'Text',
                            text: '1792',
                            type: 'text',
                            rect: [1, 170, 'auto', 'auto', 'auto', 'auto']
                        },
                        {
                            transform: [[0, 0, 0], ['-59', 0, 0], [0, 0], [1, 1, 1], ['50%', '50%']],
                            type: 'text',
                            id: 'TextCopy',
                            text: 'نيويورك (NYSE)',
                            font: ['Arial, Helvetica, sans-serif', [14, 'px'], 'rgba(0,0,0,1)', '700', 'none', '', '', 'nowrap'],
                            rect: [-15, 75, 'auto', 'auto', 'auto', 'auto']
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
                            rect: ['0', '0', '142px', '28px', 'auto', 'auto'],
                            id: 'Rectangle4',
                            stroke: [1, 'rgba(255,0,0,1.00)', 'solid'],
                            cursor: 'pointer',
                            fill: ['rgba(0,0,0,1.00)']
                        },
                        {
                            font: ['Arial, Helvetica, sans-serif', [20, 'px'], 'rgba(255,255,255,1.00)', 'bold', 'none', 'normal', 'break-word', 'nowrap'],
                            type: 'text',
                            align: 'left',
                            id: 'Text2',
                            text: 'العالمي',
                            cursor: 'pointer',
                            rect: ['44', '2px', 'auto', 'auto', 'auto', 'auto']
                        }
                    ],
                    style: {
                        '${symbolSelector}': {
                            rect: [null, null, '144', '39']
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
                            rect: ['0', '0', '142px', '28px', 'auto', 'auto'],
                            id: 'Rectangle4Copy',
                            stroke: [1, 'rgb(255, 0, 0)', 'solid'],
                            cursor: 'pointer',
                            fill: ['rgba(0,0,0,1)']
                        },
                        {
                            font: ['Arial, Helvetica, sans-serif', [20, 'px'], 'rgba(255,255,255,1)', 'bold', 'none', 'normal', 'break-word', 'nowrap'],
                            type: 'text',
                            id: 'Text2Copy',
                            text: 'العربي<br>',
                            align: 'left',
                            rect: ['44', '2px', 'auto', 'auto', 'auto', 'auto']
                        }
                    ],
                    style: {
                        '${symbolSelector}': {
                            rect: [null, null, '144', '39']
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
                            rect: ['0', '0', '142px', '28px', 'auto', 'auto'],
                            id: 'Rectangle4Copy2',
                            stroke: [1, 'rgb(255, 0, 0)', 'solid'],
                            cursor: 'pointer',
                            fill: ['rgba(0,0,0,1)']
                        },
                        {
                            font: ['Arial, Helvetica, sans-serif', [20, 'px'], 'rgba(255,255,255,1)', 'bold', 'none', 'normal', 'break-word', 'nowrap'],
                            type: 'text',
                            id: 'Text2Copy2',
                            text: 'الخليجي<br>',
                            align: 'left',
                            rect: ['44', '2px', 'auto', 'auto', 'auto', 'auto']
                        }
                    ],
                    style: {
                        '${symbolSelector}': {
                            rect: [null, null, '144', '39']
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
