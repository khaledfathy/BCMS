var tiles = new Array(),
	flips = new Array('tb', 'bt', 'lr', 'rl'),
	iFlippedTile = null,
	iTileBeingFlippedId = null,
	tileAllocation = [],
	iTimer = 0,
	iInterval = 100,
	iPeekTime = 0,
	state = false,
    tValue,
    timer_is_on = 0,
    rnew_game = true,
    Timer,
    TotalSeconds,
    TimeStr,
    Seconds,
    Minutes,
    curTile,
    totalTiles = 0,
    allCkicks = 0,
    tileLength = 0,
    sectorArray = new Array(),
    sectorArrayData = new Array(),
    sectorsData = [1, 12, 15, 14, 14, 3, 17, 6, 36, 8, 15, 17, 9, 5, 4, 4],
    TileNum,
    soundeffect = true,
    PickCopmlete = false,
    GameType,
    newSC = 237,
    bheight = 264,
    ArrayTest = [],
    filpEnd = false;


function getRandomImageForTile() {


    var iRandomImage = Math.floor((Math.random() * sectorArray.length));

    for (var i = 0; i < tileAllocation.length; i++) {
        if (iRandomImage == tileAllocation[i]) {
            iRandomImage = Math.floor((Math.random() * sectorArray.length));
            i = 0;
        }
    };


   
    return iRandomImage;
}

function createTile(iCounter) {

    curTile = new tile("tile" + iCounter),
       iRandomImage = getRandomImageForTile();

    tileAllocation.push(iRandomImage);
    if (GameType == 'SectorsCompanies') {
        curTile.ClickesCount = 0;
        curTile.sectorType = sectorArrayData[iRandomImage].sectorType;
        curTile.companyCount = sectorArrayData[iRandomImage].companyCount;
        curTile.setFrontColor("tileColor1");
        if (curTile.sectorType==1) {

            curTile.setFrontNumberColor('tileNumberColor');

        } else {
            curTile.setFrontNumberColor('tileNumberColor2');

        }
        curTile.setStartAt(500 * Math.floor((Math.random() * 5) + 1));
        curTile.setFlipMethod(flips[Math.floor((Math.random() * 4))]);

        curTile.setBackContentImage("/Areas/Games/Materials/CompaniesImagesName/" + (sectorArray[iRandomImage]) + ".png");

        curTile.imgno = sectorArrayData[iRandomImage].imgno;
        totalTiles = tileAllocation.length;

        return curTile;
    }

    else {
        curTile.ClickesCount = 0;
        curTile.setFrontColor("tileColor1");

        if (curTile.sectorType == 1) {
            curTile.setFrontNumberColor('tileNumberColor');
        }
        else {
            curTile.setFrontNumberColor('tileNumberColor5');
        }

        curTile.setStartAt(500 * Math.floor((Math.random() * 5) + 1));
        curTile.setFlipMethod(flips[Math.floor((Math.random() * 4))]);
        curTile.setBackContentImage("/Areas/Games/Materials/CompaniesImagesName/" + (sectorArray[iRandomImage]) + ".png");

        curTile.imgno = iRandomImage;

        var curTile2 = new tile("tile" + (iCounter + 1));
        curTile2.ClickesCount = 0;
        curTile2.setFrontColor("tileColor1");
        if (curTile2.sectorType == 1) {
            curTile2.setFrontNumberColor('tileNumberColor');
        } else {
            curTile2.setFrontNumberColor('tileNumberColor2');
        }
        

        curTile2.setStartAt(500 * Math.floor((Math.random() * 5) + 1));
        curTile2.setFlipMethod(flips[Math.floor((Math.random() * 4))]);
        curTile2.setBackContentImage("/Areas/Games/Materials/CompaniesImagesCode/" + (sectorArray[iRandomImage]) + ".png");
       
        curTile2.imgno = iRandomImage;
        totalTiles = tileAllocation.length;
        return [curTile, curTile2];
    }

}

function initState() {
    tileAllocation = new Array(sectorArray.length);
    while (tiles.length > 0) {
        tiles.pop();
    }
    $('#board').empty();
    iTimer = 0;

}
function initTiles() {
    var iCounter = 0,
		_tile = null;

    initState();

    if (GameType == 'SectorsCompanies') {
        var i = 1;
        for (iCounter = 0; iCounter < sectorArray.length; iCounter += 1) {
            _tile = createTile(iCounter);

            tiles[iCounter] = _tile;
        }

        var myArr = [];

        for (i = 0; i < sectorArray.length; i++) {
            myArr.push(i);
        }
        var number = 1;

      

        while (myArr.length > 0) {

            //choose random from array
            var iRandomtile = Math.floor((Math.random() * myArr.length));
            // set number abouve Tile

            tiles[myArr[iRandomtile]].frontNumber = number;
            number++;
            // fill board
            $('#board').append(tiles[myArr[iRandomtile]].getHTML());
            for (kk = iRandomtile; kk < myArr.length - 1; kk++) {
                myArr[kk] = myArr[kk + 1];
            }
            myArr.pop();
        };

    }
    else {
        var i = 1;
        for (iCounter = 0; iCounter < sectorArray.length * 2; iCounter += 2) {
            _tile = createTile(iCounter);

            tiles[iCounter] = (_tile[0]);
            tiles[iCounter + 1] = (_tile[1]);
        }
   
        var myArr = [];

        for (i = 0; i < sectorArray.length * 2; i++) {
            myArr.push(i);
        }

     
     
        var number = 1;
        while (myArr.length > 0) {

            //choose random from array
            var iRandomtile = Math.floor((Math.random() * myArr.length));
            // set number abouve Tile

            tiles[myArr[iRandomtile]].frontNumber = number;
            number++;
            // fill board
            $('#board').append(tiles[myArr[iRandomtile]].getHTML());
            for (kk = iRandomtile; kk < myArr.length - 1; kk++) {
                myArr[kk] = myArr[kk + 1];
            }
            myArr.pop();
        };
    }


}

function hideTiles(callback) {
    var iCounter = 0;
    for (iCounter = 0; iCounter < tiles.length; iCounter++) {
        tiles[iCounter].revertFlip();
    }
    callback();
}

function revealTiles(callback) {
    var iCounter = 0,
		bTileNotFlipped = false;
    for (iCounter = 0; iCounter < tiles.length; iCounter++) {
        if (tiles[iCounter].getFlipped() == false) {
            if (iTimer > tiles[iCounter].getStartAt()) {
                tiles[iCounter].flip();
            }
            else {
                bTileNotFlipped = true;
            }
        }
    }

    iTimer = iTimer + iInterval;

    if (bTileNotFlipped === true) {
        setTimeout("revealTiles(" + callback + ")", iInterval);
    } else {
        callback();
    }
}


function sound(item) {
    if (item == true) {
        AudioFX('/sounds/pool', { formats: ['ogg', 'mp3', 'm4a'], volume: 0.1, pool: 20 }).play();
    } else {
        AudioFX('/sounds/single', { formats: ['ogg', 'mp3', 'm4a'], volume: 0.1 }).play();

    }
}


function playAudio(sAudio) {
    var audioElement = document.getElementById('audioEngine');
    if (audioElement !== null) {
        audioElement.src = sAudio;
        audioElement.play();
    }
}

function CreateTimer(TimerID, Time) {
    Timer = document.getElementById(TimerID);
    TotalSeconds = Time;
    Seconds = 0;
    TotalSeconds = 0;
    Tick();
    if (!timer_is_on) {
        timer_is_on = 1;
        UpdateTimer();
    }
}

function Tick() {
    TotalSeconds += 1;
    UpdateTimer();
    tValue = setTimeout("Tick()", 1000);
}
function UpdateTimer() {
    Seconds = TotalSeconds;
    Minutes = Math.floor(Seconds / 60);
    Seconds -= Minutes * (60);
    TimeStr = LeadingZero(Minutes) + ":" + LeadingZero(Seconds)
    Timer.innerHTML = TimeStr;
}
function LeadingZero(Time) {

    return (Time < 10) ? "0" + Time : Time + "";

}
function restTimer(TimerID, Time) {
    clearTimeout(tValue);
    Timer = document.getElementById(TimerID);
    TotalSeconds = 0;
    TimeStr = /*((Days > 0) ? Days + " days " : "") + LeadingZero(Hours) + ":" +*/ LeadingZero(0) + ":" + LeadingZero(0)
    Timer.innerHTML = TimeStr;

}




function getNewScore() {
    newSC = 237;
    var x = (newSC / 264) * 100;
    var score = 100 - x;
    document.getElementById('sqr').innerHTML = '% '+ Math.round(score) ;
}
function restNewScore() {
    newSC = 237;
    var x = (newSC / 264) * 100;
    var score = 100 - x;
    document.getElementById('sqr').innerHTML = '% ' + Math.round(score);;
    $('.ScoreLoading').css({ height: newSC });
}

function getAllClicks() {
 
    document.getElementById('nClicks').innerHTML = ClickesCount;
}
function restAllClicks() {
   
    ClickesCount = 0;
    document.getElementById('nClicks').innerHTML = ClickesCount;
}



function gameScore(item) {
    $('.ScoreLoading').css({ height: item });
    var score = ((bheight - item) / 264) * 100;
    document.getElementById('sqr').innerHTML = '% ' + Math.round(score);;
    if (score < 0) {
        showGameOverHelp();
        filpEnd =true;
    }

}
function checkMatch() {
    if (iFlippedTile == null) {
        iFlippedTile = iTileBeingFlippedId;
    } else {
    
        //if (tiles[iFlippedTile].getBackContentImage() !== tiles[iTileBeingFlippedId].getBackContentImage()) {
        if (tiles[iFlippedTile].imgno !== tiles[iTileBeingFlippedId].imgno) {
            /////in case Error
            //newSC += (tiles[iFlippedTile].ClickesCount+ tiles[iTileBeingFlippedId].ClickesCount);
            //(sectorArray.length)
            //var scValue = (237 / 4);
            var scValue = (237 / ((sectorArray.length)*2));
            newSC += (scValue > 0 ? scValue : 0);


            setTimeout("tiles[" + iFlippedTile + "].revertFlip()", 2000);
            setTimeout("tiles[" + iTileBeingFlippedId + "].revertFlip()", 2000);
         
            if (soundeffect == true) {
                sound(false);
            }
            state = false;
         
            ClickesCount++;
            gameScore(newSC);

        }
        else
        {
            //----------------------------------------------------------------------
            if (GameType == 'SectorsCompanies') {
                
                if (tiles[iFlippedTile].sectorType + tiles[iTileBeingFlippedId].sectorType > 0) {
                    if (soundeffect == true) {
                        sound(true);
                    }
                 
                  
                  
                    var scValue = (237 / (tileLength)); // (tiles[iFlippedTile].ClickesCount + tiles[iTileBeingFlippedId].ClickesCount);
                    newSC -= (scValue > 0 ? scValue : 0);
                    state = true;
                    if (tiles[iFlippedTile].sectorType == 1)
                    {
                        
                        tiles[iFlippedTile].companyCount = tiles[iFlippedTile].companyCount - 1;
                        if (tiles[iFlippedTile].companyCount == 1) {
                            totalTiles = totalTiles - 2;
                        }
                        else {
                            
                            totalTiles = totalTiles - 1;
                            setTimeout("tiles[" + iFlippedTile + "].revertFlip()", 2000);
                        }

                    }
                    else
                    {
                        tiles[iTileBeingFlippedId].companyCount = tiles[iTileBeingFlippedId].companyCount - 1;
                        if (tiles[iTileBeingFlippedId].companyCount == 1)
                        {
                            totalTiles = totalTiles - 2;
                        }
                        else
                            {
                            
                            totalTiles = totalTiles - 1;
                            setTimeout("tiles[" + iTileBeingFlippedId + "].revertFlip()", 2000);
                        }

                    }
                    

                    if (totalTiles == 0) {
                        clearTimeout(tValue);
                        timer_is_on = 0;
                    }


                }//===========================================================================================
                else {
                    if (soundeffect == true) {
                        sound(false);
                    }

                    /////

                    // newSC += (tiles[iFlippedTile].ClickesCount + tiles[iTileBeingFlippedId].ClickesCount);

                    var scValue = (237 / ((sectorArray.length) * 2));
                    newSC += (scValue > 0 ? scValue : 0);

                    setTimeout("tiles[" + iFlippedTile + "].revertFlip()", 2000);
                    setTimeout("tiles[" + iTileBeingFlippedId + "].revertFlip()", 2000);

                }
                //---------------------------------------------------------------------------------------------------------
                ClickesCount++;
                gameScore(newSC);
               
            }
            else {
            
                if (soundeffect == true) {
                    sound(true);
                }
                var scValue = (237 / (sectorArray.length)); // (tiles[iFlippedTile].ClickesCount + tiles[iTileBeingFlippedId].ClickesCount);
                newSC -= (scValue > 0 ? scValue : 0);

                //getNewScore();
                ClickesCount++;
                gameScore(newSC);
                state = true;

                totalTiles = totalTiles - 2;

                if (totalTiles == 0) {
                    clearTimeout(tValue);
                    timer_is_on = 0;
                }
            }
        }
        getAllClicks();
        iFlippedTile = null;
        iTileBeingFlippedId = null;
    }
}

function onPeekComplete() {
    $('div.tile').click(function () {
        iTileBeingFlippedId = this.id.substring("tile".length);
        
        if (tiles[iTileBeingFlippedId].getFlipped() === false && filpEnd == false) {
            getAllClicks();
            tiles[iTileBeingFlippedId].ClickesCount++;
            tiles[iTileBeingFlippedId].addFlipCompleteCallback(function () { checkMatch(); });
            tiles[iTileBeingFlippedId].flip();

        }

    });
}

function onPeekStart() {
    if (PickCopmlete == true) {
        setTimeout("hideTiles( function() { onPeekComplete(); })", iPeekTime);
        restTimer('tim', 0);
        CreateTimer('tim', 0)
        restNewScore();
        restAllClicks();
    }
    PickCopmlete = false;

}
$(document).ready(function ()
    {
        $('#btndone').click(function () {
            initTiles();
            setTimeout("revealTiles(function() { onPeekStart(); })", 100);
            restTimer('tim', 0);
            CreateTimer('tim', 0)
            restNewScore();
            restAllClicks();
        });
    });

$(document).ready(function () {

    $('#btt').bind("click", function ()
    {
        //tiles.length = 0;
        ////$('#board').html("");or
        //$('#board').empty();
        //setTimeout("revealTiles(function() { onPeekStart(); })", iInterval);
        //restTimer('tim', 0);
        //CreateTimer('tim', 0)
        //restNewScore();
        //restAllClicks();
    });
});
function ClearTiles() {
    filpEnd = false;
    sectorArray.length = 0;
    tiles.length = 0;
    //$('#board').html("");or
    $('#board').empty();
};

$(document).ready(function () {
    $('#divOkAlert').bind("click", function () {
        tiles.length = 0;
        $('#board').empty();
        sectorArray.length = 0;
        initTiles();
        setTimeout("revealTiles(function() { onPeekStart(); })", 100);
        restTimer('tim', 0);
        CreateTimer('tim', 0)
        restNewScore();
        restAllClicks();
    });
});
$(document).ready(function () {

    $('#liNew').bind("click", function () {
        tiles.length = 0;
        $('#board').empty();
        //sectorArray.length = 0;
        initTiles();
        setTimeout("revealTiles(function() { onPeekStart(); })", 100);
        restTimer('tim', 0);
        restNewScore();
        restAllClicks();
        CreateTimer('tim', 0)
    });
});