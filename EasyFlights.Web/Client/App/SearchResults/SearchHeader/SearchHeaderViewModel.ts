import ko = require("knockout");
import { SearchHeaderItem } from "./SearchHeaderItem";

import SearchHeaderOptions = require("./ISearchHeaderOptions");

class SearchHeaderViewModel {

    public item: SearchHeaderItem;

    constructor(options: SearchHeaderOptions.ISearchHeaderItemOptions) {

        this.item = options.item;

    }
}

export = SearchHeaderViewModel;