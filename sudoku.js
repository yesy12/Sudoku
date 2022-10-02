
    let line1Value = "";
    let line2Value = "";
    let line3Value = "";
    let line4Value = "";
    let line5Value = "";
    let line6Value = "";
    let line7Value = "";
    let line8Value = "";
    let line9Value = "";
 
    let column1Value = "";
    let column2Value = "";
    let column3Value = "";
    let column4Value = "";
    let column5Value = "";
    let column6Value = "";
    let column7Value = "";
    let column8Value = "";
    let column9Value = "";

    let group1Value = "";
    let group2Value = "";
    let group3Value = "";
    let group4Value = "";
    let group5Value = "";
    let group6Value = "";
    let group7Value = "";
    let group8Value = "";
    let group9Value = "";

window.onload = () =>{


    group1 = [[,"1x1"],[,"1x2"],[,"1x3"],    [,"1x4"],[,"1x5"],[,"1x6"],  [,"1x7"],[,"1x8"],[,"1x9"]];
    group2 = [[,"2x1"],[,"2x2"],[,"2x3"],    [,"2x4"],[,"2x5"],[,"2x6"],  [,"2x7"],[,"2x8"],[,"2x9"]];
    group3 = [[,"3x1"],[,"3x2"],[,"3x3"],    [,"3x4"],[,"3x5"],[,"3x6"],  [,"3x7"],[,"3x8"],[,"3x9"]];

    group4 = [[,"4x1"],[,"4x2"],[,"4x3"],    [,"4x4"],[,"4x5"],[,"4x6"],  [,"4x7"],[,"4x8"],[,"4x9"]];
    group5 = [[,"5x1"],[,"5x2"],[,"5x3"],    [,"5x4"],[,"5x5"],[,"5x6"],  [,"5x7"],[,"5x8"],[,"5x9"]];
    group6 = [[,"6x1"],[,"6x2"],[,"6x3"],    [,"6x4"],[,"6x5"],[,"6x6"],  [,"6x7"],[,"6x8"],[,"6x9"]];
    
    group7 = [[,"7x1"],[,"7x2"],[,"7x3"],    [,"7x4"],[,"7x5"],[,"7x6"],  [,"7x7"],[,"7x8"],[,"7x9"]];
    group8 = [[,"8x1"],[,"8x2"],[,"8x3"],    [,"8x4"],[,"8x5"],[,"8x6"],  [,"8x7"],[,"8x8"],[,"8x9"]];
    group9 = [[,"9x1"],[,"9x2"],[,"9x3"],    [,"9x4"],[,"9x5"],[,"9x6"],  [,"9x7"],[,"9x8"],[,"9x9"]];

    sudoku = [group1,group2,group3,group4,group5,group6, group7,group8,group9];
    
    sudoku.forEach(group => {
        group.forEach(element =>{
            let line_current = element[1].split("x")[0];
            let column_current = element[1].split("x")[1];

            addOnLines(line_current,element[0]);
            addOnColumn(column_current,element[0]);
            addOnGroups(element[1],element[0] );

            addOnElement(`${element[1]}`, element[0]);
            
        })
    });

    consoleColumns();
    consoleLines();



    let linesValues = [
        [line1Value,"1"],[line2Value,"2"],[line3Value,"3"],
        [line4Value,"4"],[line5Value,"5"],[line6Value,"6"],
        [line7Value,"7"],[line8Value,"8"],[line9Value,"9"]
    ]

    let columnsValues = [
        [column1Value,"1"],[column2Value,"2"],[column3Value,"3"],
        [column4Value,"4"],[column5Value,"5"],[column6Value,"6"],
        [column7Value,"7"],[column8Value,"8"],[column9Value,"9"]
    ]

    let groupsValues = [
        [group1Value,"group1"],[group2Value,"group2"],[group3Value,"group3"],
        [group4Value,"group4"],[group5Value,"group5"],[group6Value,"group6"],
       [group7Value,"group7"],[group8Value,"group8"],[group9Value,"group9"]
    ]

    linesValues.forEach(line => {
        verifyLines(line[0],line[1]);
    });

    columnsValues.forEach(column =>{
        verifyColumns(column[0],column[1]);
    });
    
    groupsValues.forEach(group =>{
        verifyGroups(group[0],group[1]);
    });

}

function addOnColumn(column_value, element_){
    if(element_ == undefined){
        element_ = 0;
    }

    switch  (column_value){

        case "1":
            column1Value += `${element_}`;
            break;
        case "2":
            column2Value += `${element_}`;
            break;
        case "3":
            column3Value += `${element_}`;
            break;
        case "4":
            column4Value += `${element_}`;
            break;
        case "5":
            column5Value += `${element_}`;
            break;
        case "6":
            column6Value += `${element_}`;
            break;               
        case "7":
            column7Value += `${element_}`;
            break;
        case "8":
            column8Value += `${element_}`;
            break;
        case "9":
            column9Value += `${element_}`;
            break;
        case "":
            console.log("3");
            break;
        default:
            console.log(column_value);
            break;
    }



}

function addOnLines(line_value, element_){
    if(element_ == undefined){
        element_ = 0;
    }

    switch  (line_value){

        case "1":
            line1Value += `${element_}`;
            break;
        case "2":
            line2Value += `${element_}`;
            break;
        case "3":
            line3Value += `${element_}`;
            break;

        case "4":
            line4Value += `${element_}`;
            break;
        case "5":
            line5Value += `${element_}`;
            break;
        case "6":
            line6Value += `${element_}`;
            break;
                
        case "7":
            line7Value += `${element_}`;
            break;
        case "8":
            line8Value += `${element_}`;
            break;
        case "9":
            line9Value += `${element_}`;
            break;

    }

}

function addOnGroups(group_value, element_){
    let parent;
    let groupId;

    parent = document.getElementById(group_value).parentNode;
    groupId = parseInt(parent.id.split("group")[1]);

    switch  (groupId){

        case 1:
            group1Value += `${element_}`;
            break;
        case 2:
            group2Value += `${element_}`;
            break;
        case 3:
            group3Value += `${element_}`;
            break;

        case 4:
            group4Value += `${element_}`;
            break;
        case 5:
            group5Value += `${element_}`;
            break;
        case 6:
            group6Value += `${element_}`;
            break;
                
        case 7:
            group7Value += `${element_}`;
            break;
        case 8:
            group8Value += `${element_}`;
            break;
        case 9:
            group9Value += `${element_}`;
            break;
    }
}

function addOnElement(element,value_){
    if(value_ != ""){
        document.getElementById(element).value = value_;
    }
}


function verifyLines(lineCurrentElement, lineValue){
    let elements = [];
    let exists = 0;
    let value;

    for(i = 0; i < lineCurrentElement.length;i++){
        value = lineCurrentElement[i];
        exists = elements.includes(value);

        if(value != 0){
            if( !exists ){
                elements.push(value);
            }
            else{
                document.getElementById(`${lineValue}x${i+1}`).classList.add("red");
            }
        }
    }
}

function verifyColumns(columnCurrentElement, columnValue){
    let elements = [];
    let exists = 0;
    let value;

    for(i = 0; i < columnCurrentElement.length; i++){
        value = columnCurrentElement[i];
        exists = elements.includes(value);

        if(value != 0){
            if( !exists ){
                elements.push(value);
            }
            else{
                document.getElementById(`${i+1}x${columnValue}`).classList.add("red");
            }
        }
    }
}

function verifyGroups(groupCurrentElement, groupValue){
    let elements = [];
    let exists = 0;
    let value = 0;

    for(i = 0; i < groupCurrentElement.length; i++){
        value = groupCurrentElement[i];
        exists = elements.includes(value);
        
        if(value != 0){
            if(!exists){
                elements.push(value);
            }
            else{
                console.log(`${exists}||${value}`);
                console.log(document.getElementById(groupValue).children[i].classList.add("red"));
            }
        }
    }
}


function consoleColumns(){
    console.log(`
        \nColuna1:${column1Value}\nColuna2:${column2Value}\nColuna3:${column3Value}
        \nColuna4:${column4Value}\nColuna5:${column5Value}\nColuna6:${column6Value}
        \nColuna7:${column7Value}\nColuna8:${column8Value}\nColuna9:${column9Value}
    `)
}

function consoleLines(){
    console.log(`
        \nLinha1:${line1Value}\nLinha2:${line2Value}\nLinha3:${line3Value}
        \nLinha4:${line4Value}\nLinha5:${line5Value}\nLinha6:${line6Value}
        \nLinha7:${line7Value}\nLinha8:${line8Value}\nLinha9:${line9Value}
    `)
}