import { Component, OnInit } from "@angular/core";
import { BookkeepingService } from "../bookkeeping.service";
//import { BsDatepickerConfig, BsDatepickerViewMode } from 'ngx-bootstrap/datepicker';

@Component({
  templateUrl: './reconciliation.component.html',
})

export class ReconciliationComponent implements OnInit  {
  //datePickerValue: Date = new Date(2020, 7);
  //dateRangePickerValue: Date[];
  //range1: Date = new Date(2020, 5);
  //range2: Date = new Date(2020, 8);
  //minMode: BsDatepickerViewMode = 'month';
  //bsConfig: Partial<BsDatepickerConfig>;
  reconciliationItem: any[] = null;

  public constructor(private _bookkeepingService: BookkeepingService) {
  }

  ngOnInit(): void {
    //this.dateRangePickerValue = [this.range1, this.range2];
    //this.bsConfig = Object.assign({}, {
    //  minMode: this.minMode
    //});

    this._bookkeepingService.getReconciliationItem().subscribe(result => {
      this.reconciliationItem = result;
    })
  }
}
