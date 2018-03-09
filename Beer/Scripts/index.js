$(document).ready(function () {

    //search
    $(document).on("click", "#search", function (elem) {
        getBeers(getFilterParams());
    });

    //reset
    $(document).on("click", "#reset", function (elem) {
        const name = $("#name").val('');
        const organic = $("#organic").prop("checked", false);
        getBeers('');
    });

    //sort
    $(document).on("click", "th.sortable", function (elem) {
        sortBy(elem);
        getBeers(getFilterParams() + "&" + getSortParams());
    });

    //previous page
    $(document).on("click", ".prev", function (elem) {
        let currentPage = getCurrentPage();
        if (currentPage == 1)
            return;

        getBeers(getFilterParams() + "&" + getSortParams() + "&" + `page=${--currentPage}`);
    });

    //next page
    $(document).on("click", ".next", function (elem) {
        let currentPage = getCurrentPage();
        const totalPages = $("#total-pages").val();
        if (currentPage == totalPages)
            return;

        getBeers(getFilterParams() + "&" + getSortParams() + "&" + `page=${++currentPage}`);
    });

    getBeers('');
});

function getBeers(params) {
    const beersBaseUrl = "Home/Beers";
    const beersUrl = `${beersBaseUrl}?${params}`;

    $("#grid-body").empty();
    $.getJSON(beersUrl).done(function (beerGrid) {
        $.each(beerGrid.Data, function (index, value) {
            $(formatBeerRow(value)).appendTo($("#grid-body"));
        });

        $("#current-page").val(beerGrid.CurrentPage);
        $(".current-page").text(beerGrid.CurrentPage);
        $("#total-pages").val(beerGrid.NumberOfPages);
        $(".total-pages").text(beerGrid.NumberOfPages);
    });
}

function getFilterParams() {
    const name = $("#name").val();
    const organic = $("#organic").prop("checked");

    let result = '';
    result += name ? `name=${name}` : '';
    result += organic ? `&isOrganic=${organic}` : '';

    return result;
}

function getSortParams() {
    return $("#grid").attr("sort-params");
}

function sortBy(elem) {
    const columnName = $(elem.target).attr("data-name");
    let columnSortOrder = $(elem.target).attr("data-sort");
    if (columnSortOrder)
        columnSortOrder = columnSortOrder === "asc" ? "desc" : "asc";
    else
        columnSortOrder = "asc";
    $(elem.target).attr("data-sort", columnSortOrder);

    $("#grid").attr("sort-params", `order=${columnName}&sort=${columnSortOrder}`);
}

function getCurrentPage() {
    return $("#current-page").val();
}

function formatBeerRow(item) {
    $.each(Object.keys(item), function (index, key) {
        if (item[key] === undefined || item[key] === null)
            item[key] = '';
    });
    return '<tr>' +
                '<td>' + item.Id + '</td>' +
                '<td>' + item.Name + '</td>' +
                '<td>' + item.Abv + '</td>' +
                '<td>' + item.Ibu + '</td>' +
                '<td>' + item.Glass + '</td>' +
                '<td>' + item.Available + '</td>' +
                '<td>' + item.IsOrganic + '</td>' +
                '<td>' + item.StatusDisplay + '</td>' +
                '<td>' + ToJavaScriptDate(item.CreateDate) + '</td>' +
            '</tr>';
}

function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear();
}
