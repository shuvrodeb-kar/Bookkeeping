import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { catchError, map } from 'rxjs/operators';
import { throwError as observableThrowError, Observable } from 'rxjs';

@Injectable({
  providedIn:'root'
})

export class BookkeepingService {
  baseUrl: string = null;
  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getReconciliationItem(): Observable<any> {
    return this._http.get<any>(this.baseUrl + 'api/ReconciliationItem').pipe(
      map(this.extractData),
      catchError(this.handleError));
  }

  private extractData(res: Response) {
    return res;
  }

  private handleError(error) {
    const errMsg = (error.message) ? error.message :
      error.status ? `${error.status} - ${error.statusText}` : 'Server error';
    console.error(errMsg);
    return observableThrowError(errMsg);
  }

}


//interface ReconciliationItem {
//  Id: number;
//  IncomeExpenseType: number;
//  ItemName: string;
//}

