import { Employee } from './employee.modal';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable, EMPTY } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { MessageResponse } from './message.modal';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private readonly _baseUrl: string;

  constructor(private snackBar: MatSnackBar, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this._baseUrl = `${environment.API}api/employee`;
  }

  showMessage(msg: string, isError: boolean = false): void {
    this.snackBar.open(msg, 'X', {
      duration: 5000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: isError ? ['msg-error'] : ['msg-success'] 
    })
  }

  read(): Observable<MessageResponse<Employee[]>> {
    return this.http.get<MessageResponse<Employee[]>>(this._baseUrl).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    )
  }

  create(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(`${this._baseUrl}`, employee).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    )
  }

  calculate(minimumWage: any): Observable<MessageResponse<Employee[]>> {
    const url = `${this._baseUrl}/getcalculationir?minimumWage=${minimumWage}`
    return this.http.get<MessageResponse<Employee[]>>(url).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    )
  }

  errorHandler(e: any): Observable<any> {
    console.log(e)
    this.showMessage('Ocorreu um erro!', true)
    return EMPTY
  }

}
