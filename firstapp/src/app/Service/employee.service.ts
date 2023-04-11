import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { EmployeeCombine } from '../Model/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  tempId=0;
  tempEmployee!:EmployeeCombine;
  constructor(private http:HttpClient) { }
  baseurl="http://localhost:5231/api/Employee";
  getEmployee(){
   return this.http.get<EmployeeCombine[]>(this.baseurl);
  }
  createEmployee(postData:EmployeeCombine){
    postData.id=0;
    postData.empid=0;
    return this.http.post(this.baseurl,postData);

  }
  deleteEmployee(){
   return this.http.delete(this.baseurl+'/'+this.tempId);
  }

  putEmployee(postData:EmployeeCombine){
    
    return this.http.put(this.baseurl+'/'+this.tempId,postData);
  }
}
