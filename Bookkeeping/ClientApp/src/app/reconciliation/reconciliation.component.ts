import { Component, OnInit } from "@angular/core";
import { BookkeepingService } from "../bookkeeping.service";
import * as _ from 'underscore';

import { BsDatepickerConfig, BsDatepickerViewMode } from 'ngx-bootstrap/datepicker';

@Component({
  templateUrl: './reconciliation.component.html',
})

export class ReconciliationComponent implements OnInit  {
  datePickerValue: Date = new Date(2020, 7);
  dateRangePickerValue: Date[];
  range1: Date = new Date(2020, 5);
  range2: Date = new Date(2020, 8);
  minMode: BsDatepickerViewMode = 'month';
  bsConfig: Partial<BsDatepickerConfig>;
  reconciliationItems: any[] = null;
  incomeExpenseType = IncomeExpense;
  incomeExpenseTypeEnumKeys = [];
  selectedValue: string = null;
  itemList: any[] = null;
  
  public constructor(private _bookkeepingService: BookkeepingService) {
    this.incomeExpenseTypeEnumKeys = Object.keys(this.incomeExpenseType).filter(f => !isNaN(Number(f)));
    console.log(this.incomeExpenseTypeEnumKeys);
    this.selectedValue = this.incomeExpenseTypeEnumKeys[0];
  }

  ngOnInit(): void {
    this.dateRangePickerValue = [this.range1, this.range2];
    this.bsConfig = Object.assign({}, {
      minMode: this.minMode
    });

    this._bookkeepingService.getReconciliationItem().subscribe(result => {
      this.reconciliationItems = result;
      this.itemList = _.where(this.reconciliationItems, { incomeExpenseType: IncomeExpense.Income });     
    })
  }

  onChange(newValue) {
    this.itemList = _.where(this.reconciliationItems, { incomeExpenseType: parseInt(newValue) });  
  }
}

export enum IncomeExpense {
  Income,
  Expense
}

