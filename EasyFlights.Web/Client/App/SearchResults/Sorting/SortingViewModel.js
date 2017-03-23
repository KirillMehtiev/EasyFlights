"use strict";
var SortingViewModel = (function () {
    function SortingViewModel() {
        var sorting = "by-price";
        this.sortingOption = ko.observable(sorting);
    }
    return SortingViewModel;
}());
module.exports = SortingViewModel;
//# sourceMappingURL=SortingViewModel.js.map