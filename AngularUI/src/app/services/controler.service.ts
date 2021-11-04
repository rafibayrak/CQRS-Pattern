import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

enum RequestType {
  GET,
  POST,
  PUT,
  DELETE,
  FILEUPLOAD
}

export class ControllerService {
  private _http: HttpClient;
  private _header = new HttpHeaders();
  private _baseUrl = environment.apiUrl;
  private _router: Router;
  constructor(
    controllerName: string,
    http: HttpClient,
    router: Router
  ) {
    this._http = http;
    this._baseUrl += controllerName;
    this._router = router;
  }

  private InvokeRequestElement(requestType: RequestType, action: string, httpParams?: HttpParams, value?: any) {
    if (requestType !== RequestType.FILEUPLOAD) {
      this._header = this._header.set('Content-Type', 'application/json; charset=utf-8');
    }

    const token = localStorage.getItem('authToken');
    if (token) {
      this._header = this._header.set('Authorization', 'Bearer ' + token);
    }

    let response: Observable<any>;
    switch (requestType) {
      case RequestType.GET:
        response = this._http.get(this._baseUrl + action, { headers: this._header, params: httpParams });
        break;
      case RequestType.POST:
        response = this._http.post(this._baseUrl + action, value, { headers: this._header, params: httpParams });
        break;
      case RequestType.PUT:
        response = this._http.put(this._baseUrl + action, value, { headers: this._header, params: httpParams });
        break;
      case RequestType.DELETE:
        response = this._http.delete(this._baseUrl + action, { headers: this._header, params: httpParams });
        break;
      case RequestType.FILEUPLOAD:
        response = this._http.post(this._baseUrl + action, value, { headers: this._header, params: httpParams, reportProgress: true, observe: 'events' });
        break;
    }

    return response.pipe(
      tap(values => {
        if (!environment.production) {
          console.log(this._baseUrl, JSON.stringify(values));
        }
      }),
      catchError(this.handleError()));
  }

  protected get(action: string, httpParams?: HttpParams) {
    return this.InvokeRequestElement(RequestType.GET, action, httpParams);
  }

  protected post(action: string, value: any, httpParams?: HttpParams) {
    return this.InvokeRequestElement(RequestType.POST, action, httpParams, value);
  }

  protected put(action: string, value: any, httpParams?: HttpParams) {
    return this.InvokeRequestElement(RequestType.PUT, action, httpParams, value);
  }

  protected delete(action: string, httpParams?: HttpParams) {
    return this.InvokeRequestElement(RequestType.DELETE, action, httpParams);
  }

  protected fileUpload(action: string, value: FormData, httpParams?: HttpParams) {
    return this.InvokeRequestElement(RequestType.FILEUPLOAD, action, httpParams, value);
  }

  //Error Handler
  private handleError<T>() {
    return (error: any): Observable<T> => {
      if (error.status === 401 || error.status === 403) {
        localStorage.removeItem(environment.authTokenName);
        this._router.navigate([environment.loginPath]);
      }

      if (!environment.production) {
        console.error(this._baseUrl, error);
      }

      return throwError(error);
    };
  }
}
