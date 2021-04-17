import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map } from 'rxjs/operators';
import { throwError as observableThrowError, Observable } from 'rxjs';

@Injectable({
  providedIn:'root'
})

export class BookkeepingService {
  constructor(private _http: HttpClient) {
  }

  getReconciliationItem(): Observable<any> {
    return this._http.get<any>('Controllers/ReconciliationItem/GetReconciliationItems').pipe(
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
