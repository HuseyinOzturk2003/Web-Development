/* ---------------------- Income Expense Start ------------------------------*/

$(document).ready(function () {
    AllIncomeExpenseList();
})

//Entire add/remove/update category list 
function AllIncomeExpenseList() {
    $.ajax({
        url: "/BudgetCalculator/GetAllIncomeExpense",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result) {
                var html = "";
                $.each(result, function (key, item) {
                    html += "<tr>";
                    html += "<td>" + item.ID + "</td>";
                    html += "<td>" + item.Name + "</td>";
                    html += "<td>" + item.Explanation + "</td>";
                    html += "<td>" + item.Price + "</td>";
                    html += "<td>" + item.AveragePrice + "</td>";
                    html += "<td>" + item.IsIncome + "</td>";
                    html += "<td>" + item.IsExpense + "</td>";
                    html += "<td>" + item.IsOneTime + "</td>";
                    html += "<td>" + item.ImagePath + "</td>";
                    html += "<td>";
                    html += "<button type='button' class='btn btn-outline-primary fw-bold m-2' onclick='return OpenUpdateIncomeExpenseModalPopUp(" + item.ID + ")'> Update Data </button > ";
                    html += "<button type='button' class='btn btn-outline-danger fw-bold m-2' onclick=DeleteIncomeExpense('" + item.ID+"')> Delete Data </button > ";
                    html += "</td>";
                    html += "</tr>";
                });
                $(".tbody").html(html);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

  //Category modal pop up
function OpenAddIncomeExpenseModalPopUp() {
    $.ajax({
        url: "/BudgetCalculator/AddIncomeExpenseModalPopUp",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "html",
        success: function (result) {
            $("#divcontent").empty();
            $("#divcontent").html(result);
            $("#AddIncomeExpenseModal").modal("show");
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
}

  //Category modal pop up with ID 
function OpenUpdateIncomeExpenseModalPopUp(ID) {
    $.ajax({
        url: "/BudgetCalculator/UpdateIncomeExpenseModalPopUp?ID=" + ID,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "html",
        success: function (result) {
            $("#divcontent").empty();
            $("#divcontent").html(result);
            $("#UpdateIncomeExpenseModal").modal("show");
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
}

function AddIncomeExpense() {

    
    //Adding an ıncome expense object
    var addIncomeExpenseObject = {
        Name: $("#Name").val(),
        Explanation: $("#Explanation").val(),
        Price: $("#Price").val(),
        AveragePrice: $("#AveragePrice").val(),
        IsIncome: $("#IsIncome").is(":checked"),
        IsExpense: $("#IsExpense").is(":checked"),
        IsOneTime: $("#IsOneTime").is(":checked"),
        ImagePath: $("#ImagePath").val()
    };



    $.ajax({
        url: "/BudgetCalculator/AddIncomeExpense",
        data: JSON.stringify(addIncomeExpenseObject),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
           
            $("#AddIncomeExpenseModal").modal("hide");
            AllIncomeExpenseList();
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

  //Update an element from the category list
function UpdateIncomeExpense() {

    var updateIncomeExpenseObject = {

        ID: $("#ID").val(),
        Name: $("#Name").val(),
        Explanation: $("#Explanation").val(),
        Price: $("#Price").val(),
        AveragePrice: $("#AveragePrice").val(),
        IsIncome: $("#IsIncome").is(":checked"),
        IsOneTime: $("#IsOneTime").is(":checked"),
        IsExpense: $("#IsExpense").is(":checked"),
        ImagePath: $("#ImagePath").val()
    };

    $.ajax({
        url: "/BudgetCalculator/UpdateIncomeExpense",
        data: JSON.stringify(updateIncomeExpenseObject),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            AllIncomeExpenseList();
            $("#UpdateIncomeExpenseModal").modal("hide");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function DeleteIncomeExpense(ID) {

    //Delete added or existing element with confirmation message
    var IncomeExpenseAnswer = confirm("Are You Sure Want To Delete");
    if (IncomeExpenseAnswer) {
        $.ajax({
            url: "/BudgetCalculator/DeleteIncomeExpense?ID=" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                AllIncomeExpenseList();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}



/* ---------------------- Income Expense Finish ------------------------------*/



/* ---------------------- Income Expense Start ------------------------------*/


function AddReportData(ID,Count) {

    //Add and give a message to the user upon addition of an item
    $.ajax({
        url: "/BudgetCalculator/AddReportsData?ID=" + ID + "&Count=" + Count,
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("item has been added");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

/* ---------------------- Income Expense Finish ------------------------------*/



function DeleteAllReportsData() {
    var IncomeExpenseAnswer = confirm("Are You Sure Want To Delete");
    if (IncomeExpenseAnswer) {
        $.ajax({
            url: "/BudgetCalculator/DeleteAllReportsData",
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }

}

