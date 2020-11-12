import { Employee } from './../employee.modal';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employeer-create',
  templateUrl: './employeer-create.component.html',
  styleUrls: ['./employeer-create.component.css']
})
export class EmployeerCreateComponent implements OnInit {

  public employeeForm: FormGroup;

  employee: Employee = {
    identificationNumber: '',
    name: '',
    grossSalary: '',
    numberOfDependants: ''
  }  

  constructor(private employeeService: EmployeeService,
    private router: Router) { }

  ngOnInit(): void {
    this.employeeForm = new FormGroup({
      $key: new FormControl(null),
      identificationNumber: new FormControl('', Validators.required),
      name: new FormControl('', Validators.required),
      grossSalary: new FormControl('', Validators.required),
      numberOfDependants: new FormControl('', Validators.required)
    });
  }

  public hasError = (controlName: string, errorName: string) =>{
    return this.employeeForm.controls[controlName].hasError(errorName);
  }

  createEmployee(employeeFormValue): void {
    if (this.employeeForm.valid) {
      this.executeEmployeeCreation(employeeFormValue);
    }
  }

  public executeEmployeeCreation = (employeeFormValue) => {
    let employee: Employee = {
      identificationNumber: employeeFormValue.identificationNumber,
      name: employeeFormValue.name,
      grossSalary: employeeFormValue.grossSalary,
      numberOfDependants: employeeFormValue.numberOfDependants
    }
 
    this.employeeService.create(employee).subscribe(() => {
        this.employeeService.showMessage('Contribuinte cadastrado com sucesso!')
        this.router.navigate(['/employees'])
    })    
  }

  cancelEmployee(): void {
    this.router.navigate(['/employees'])
  }

}
