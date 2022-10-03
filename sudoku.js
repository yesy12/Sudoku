
    let line1Value = []
    let line2Value = []
    let line3Value = []
    let line4Value = []
    let line5Value = []
    let line6Value = []
    let line7Value = []
    let line8Value = []
    let line9Value = []
 
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


    group1 = [[,"1x1", false],[4,"1x2",true],[8,"1x3",true],    [2,"1x4",true],[,"1x5",false],[,"1x6",false],  [,"1x7",false],[,"1x8",false],[1,"1x9",true]];
    group2 = [[1,"2x1",true],[,"2x2",false],[,"2x3",false],    [3,"2x4",true],[8,"2x5",true],[4,"2x6",true],  [7,"2x7",true],[2,"2x8",true],[6,"2x9",true]];
    group3 = [[3,"3x1",true],[,"3x2",false],[,"3x3",false],    [7,"3x4",true],[,"3x5",false],[1,"3x6",true],  [9,"3x7",true],[4,"3x8",true],[8,"3x9",true]];

    group4 = [[,"4x1",false],[7,"4x2",true],[2,"4x3",true],    [6,"4x4",true],[4,"4x5",true],[5,"4x6",true],  [1,"4x7",true],[8,"4x8",true],[,"4x9",false]];
    group5 = [[8,"5x1",true],[,"5x2",false],[,"5x3",false],    [,"5x4",false],[,"5x5",false],[2,"5x6",true],  [4,"5x7",true],[,"5x8",false],[,"5x9",false]];
    group6 = [[,"6x1",false],[,"6x2",false],[,"6x3",false],    [,"6x4",false],[,"6x5",false],[,"6x6",false],  [,"6x7",false],[,"6x8",false],[7,"6x9",true]];
    
    group7 = [[,"7x1",false],[8,"7x2",true],[4,"7x3",true],    [,"7x4",false],[,"7x5",false],[,"7x6",false],  [3,"7x7",true],[,"7x8",false],[,"7x9",false]];
    group8 = [[6,"8x1",true],[,"8x2",false],[,"8x3",false],    [4,"8x4",true],[1,"8x5",true],[,"8x6",false],  [,"8x7",false],[,"8x8",false],[2,"8x9",true]];
    group9 = [[,"9x1",false],[,"9x2",false],[3,"9x3",true],    [,"9x4",false],[,"9x5",false],[,"9x6",false],  [,"9x7",false],[7,"9x8",true],[4,"9x9",true]];

    sudoku = [group1,group2,group3, group4,group5,group6, group7,group8,group9];
    
    sudoku.forEach(group => {
        group.forEach(element =>{
            let line_current = element[1].split("x")[0];
            let column_current = element[1].split("x")[1];

            verifyDisable(element[[2]],element[1]);

            addOnLines(element[0], element[1], element[2]);
            // addOnColumn(column_current,element[0]);
            // addOnGroups(element[1],element[0] );

            addOnElement(element[1], element[0]);

            
        })
    });

    // consoleColumns();
    // consoleLines();


    let linesValues = [
        [line1Value],[line2Value],[line3Value],
        [line4Value],[line5Value],[line6Value],
        [line7Value],[line8Value],[line9Value]
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
        // console.log(line[0])
        verifyLines(line[0]) ;
    });

    // columnsValues.forEach(column =>{
    //     verifyColumns(column[0],column[1]);
    // });
    
    // groupsValues.forEach(group =>{
    //     verifyGroups(group[0],group[1]);
    // });

}

function verifyDisable(element_option, element_){
    document.getElementById(element_).disabled = element_option;
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

function addOnLines(element_, lineXColumn, element_option){
    let line_value = lineXColumn.split("x")[0];
    
    if(element_ == undefined){
        element_ = 0;
    }

    switch  (line_value){

        case "1":
            line1Value.push([element_,lineXColumn,element_option]);
            break;
        case "2":
            line2Value.push([element_,lineXColumn,element_option]);
            break;
        case "3":
            line3Value.push([element_,lineXColumn,element_option]);
            break;

        case "4":
            line4Value.push([element_,lineXColumn,element_option]);
            break;
        case "5":
            line5Value.push([element_,lineXColumn,element_option]);
            break;
        case "6":
            line6Value.push([element_,lineXColumn,element_option]);
            break;
                
        case "7":
            line7Value.push([element_,lineXColumn,element_option]);
            break;
        case "8":
            line8Value.push([element_,lineXColumn,element_option]);
            break;
        case "9":
            line9Value.push([element_,lineXColumn,element_option]);
            break;

    }

}

function addOnGroups(group_value, element_){
    let parent;
    let groupId;

    parent = document.getElementById(group_value).parentNode;
    groupId = parseInt(parent.id.split("group")[1]);

    if(element_ == undefined){
        element_ = 0;
    }


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
    if(value_ != "" && value_ != undefined){
        document.getElementById(element).value = value_;
    }
}


function verifyLines(paremetros){
    let elements = [];
    let exists = 0;
    let value;
    let element_option;

    let lineXColumn;

    paremetros.forEach(parametro =>{
        value = parametro[0];
        lineXColumn = parametro[1];
        element_option = parametro[2];

        if(value != 0){
            if(element_option  == true){                
                elements.push(parametro);
            } 
            else{
                document.getElementById(lineXColumn).classList.add("red");
            }           
        }

    })
    
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

    console.log(groupCurrentElement);

    for(i = 0; i < groupCurrentElement.length; i++){
        value = groupCurrentElement[i];
        exists = elements.includes(value);

        // console.log(value)
        
        if(value != 0){
            if(!exists){
                elements.push(value);
            }
            else{
                // console.log(`${exists}||${value}`);
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