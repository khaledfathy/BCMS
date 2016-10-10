var EVENTS = function (canavsId) {
    
    var e = this;
    e.canvas = document.getElementById(canavsId);
    e.ctx = e.canvas.getContext("2d");
    e.stage = undefined;
    e.listening = false;

    e.mousePos = null;
    e.mouseDown = false;
    e.mouseUp = false;
    e.mouseOver = false;
    e.mouseMove = false;

    e.currentRegion = null;
    e.regionIndex = 0;
    e.lastRegionIndex = -1;
    e.mouseOverRegionIndex = -1;

    e.clear = function () {
        e.ctx.clearRect(0, 0, e.canvas.width, e.canvas.height);
    };

    e.getCanvasPos = function () {
        var obj = e.canvas;
        var top = 0;
        var left = 0;
        while (obj.tagName != "BODY") {
            top += obj.offsetTop;
            left += obj.offsetLeft;
            obj = obj.offsetParent;
        };
        return {
            top: top,
            left: left
        };
    };


    e.setStage = function (func) {
        e.stage = func;
        e.listen();
    };

    e.reset = function (evt) {
        if (!evt) {
            evt = window.event;
        }
        e.setMousePosition(evt);

        e.regionIndex = 0;
        if (e.stage !== undefined) {
            e.stage();
        }


        e.mouseOver = false;
        e.mouseMove = false;
        e.mouseDown = false;
        e.mouseUp = false;
    };

    e.listen = function () {

        if (e.stage !== undefined) {
            e.stage();
        }


 ;
        e.canvas.addEventListener("mousemove", function (evt) {
            e.reset(evt);
        }, false);

        this.canvas.addEventListener("mouseover", function (evt) {
            e.reset(evt);
        }, false);
        this.canvas.addEventListener("mouseout", function (evt) {
            e.mousePos = null;
        }, false);
    };

    e.getMousePos = function (evt) {
        return e.mousePos;
    };

    e.setMousePosition = function (evt) {
        var mouseX = evt.clientX - e.getCanvasPos().left + window.pageXOffset;
        var mouseY = evt.clientY - e.getCanvasPos().top + window.pageYOffset;

        e.mousePos = {
            x: mouseX,
            y: mouseY
        };
    };

    e.beginRegion = function () {
        e.currentRegion = {};
        e.regionIndex++;
    };

    e.addRegionEventListener = function (type, func) {
        var event = 'on' + type;
        e.currentRegion[event] = func;
    };


    e.closeRegion = function () {
        if (e.mousePos !== null && e.ctx.isPointInPath(e.mousePos.x, e.mousePos.y)) {
            if (e.lastRegionIndex != e.regionIndex) {
                e.lastRegionIndex = e.regionIndex;
            }

            if (e.mouseDown && e.currentRegion.onmousedown !== undefined) {

                e.currentRegion.onmousedown();
                e.mouseDown = false;
            }

            else if (e.mouseUp && e.currentRegion.onmouseup !== undefined) {
                e.currentRegion.onmouseup();
                e.mouseUp = false;
            }

            else if (!e.mouseOver && e.regionIndex != e.
            mouseOverRegionIndex && e.currentRegion.onmouseover !== undefined) {
                e.currentRegion.onmouseover();
                e.mouseOver = true;
                e.mouseOverRegionIndex = e.regionIndex;
            }

            else if (!e.mouseMove && e.currentRegion.onmousemove !== undefined) {
                e.currentRegion.onmousemove();
                e.mouseMove = true;
            }
        }

        else if (this.regionIndex == this.lastRegionIndex) {
            this.lastRegionIndex = -1;
            this.mouseOverRegionIndex = -1;

            if (this.currentRegion.onmouseout !== undefined) {
                this.currentRegion.onmouseout();
            }
        }
    };


    return e;

};