function tile(id) {
	
    this.id = id;
    this.frontNumber = 0;
    this.frontNumberColor;
    this.imgBackPositionNum='IMGBackPositionNum';
	this.frontColor = 'tileColor2';
	this.backColor = 'transparent';
	//this.backColor = 'transparent';
	this.startAt = 1000;
	this.flipped = false;
	this.backContentImage = null;
	this.flipCompleteCallbacks = new Array();
	this.imgno = 0;
	this.x=0;
	this.sectorType = 0;
	this.companyCount = 0;
	this.flip = function() {
		$("#" + this.id).flip({
			direction: this.flipMethod,
			color: this.backColor,
			content: this.getBackContent(),
			onEnd: this.onFlipComplete()
		});
		$("#" + this.id).css("background-color","red");

		$("#" + this.id + " img").show();
		
		this.flipped = true;
	};
	
	this.onFlipComplete = function() {
	
		console.log("Flip complete");
		
		while(this.flipCompleteCallbacks.length > 0) {
			
			console.log("Running callback " + this.flipCompleteCallbacks[this.flipCompleteCallbacks.length - 1]);
			this.flipCompleteCallbacks[this.flipCompleteCallbacks.length - 1]();
			this.flipCompleteCallbacks.pop();
		}
	};
	
	this.revertFlip = function() {

		console.log("Reverting tile " + this.id);
		
		$("#" + this.id + " img").hide();
		
		$("#" + this.id).revertFlip();

		this.flipped = false;
	};
	
	this.setBackContentImage = function(sBackContentImage) {
	    this.backContentImage = sBackContentImage;
	    console.log('kkkkkkkkkk'+this.backContentImage);
	};
	
	this.setTileId = function(sIdOfTile) {
		this.id = sIdOfTile;
	};

	this.setStartAt = function(iStartAt) {
		this.startAt = iStartAt;
	};
	
	this.setFrontColor = function(sColor) {
		this.frontColor = sColor;
	};


	this.setBackColor = function(sColor) {
		this.backColor = sColor;
	};

	this.setFlipMethod = function(sFlipMethod) {
		this.flipMethod = sFlipMethod;
	};
	
	this.setFrontNumber = function(sNumber) {
	    this.frontNumber = sNumber;
	};
	this.setFrontX = function (sX) {
	    this.x = sX;
	};
	this.setFrontNumberColor = function (nColor) {
	    this.frontNumberColor = nColor;
	};
	this.getHTML = function () {

	    //return '<div id="' + this.id + '" class="tile ' + this.frontColor + '">' + '<div  class=tileNumberColor>' + this.frontNumber + '</div>' + '</div>';
	    return '<div id="' + this.id + '" class="tile ' + this.frontColor + '">' + '<div  class="'+this.frontNumberColor+'">' + this.frontNumber + '</div>' + '</div>';

	};

	this.getStartAt = function() {
		return this.startAt;
	};

	this.getFlipped = function() {
		return this.flipped;
	};
	
	this.getBackContent = function() {
	    //return '<img style="width:100% ; height:100% ; margin: 0px" src="' + this.backContentImage + '"/>';
	    //return '<img style="width:100% ; height:100% ; margin: 0px;position: absolute !important; bottom: 0px !important;right: 0 !important;z-index: 9 !important;" src="' + this.backContentImage + '"/>' +
        //    '<div style="position: absolute !important; bottom: 0px !important;right: 0 !important;z-index: 10 !important;"  class="' + this.frontNumberColor + '">' + this.frontNumber + '</div>';

	    return '<img class="IMGBackPosition" src="' + this.backContentImage + '"/>' +
          '<div  class="' +this.imgBackPositionNum +' ' + this.frontNumberColor + '">' + this.frontNumber + '</div>';



	};

	this.getBackContentImage = function() {
		return this.backContentImage;
	};
	
	this.addFlipCompleteCallback = function(callback) {
		this.flipCompleteCallbacks.push(callback);
	};
}