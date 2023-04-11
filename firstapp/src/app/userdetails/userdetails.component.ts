import { Component, DoCheck, OnChanges, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import {Router} from '@angular/router';
import { EmployeeService } from '../Service/employee.service';

@Component({
  selector: 'app-userdetails',
  templateUrl: './userdetails.component.html',
  styleUrls: ['./userdetails.component.css']
})
export class UserdetailsComponent implements OnInit {
 
  EmployeeForms:FormGroup;
  
    
  
  updatactive=false;
  constructor(private route:Router,private empservice:EmployeeService) { 
    

  }

  ngOnInit(){
    this.EmployeeForms=new FormGroup({
    'id':new FormControl(null,Validators.required),
     'empid':new FormControl(null),
      'name':new FormControl(null,Validators.required),
      'sex':new FormControl('male',Validators.required),
      'address':new FormControl(null,Validators.required),
      'maritalstatus':new FormControl('married',Validators.required),
      'department':new FormControl(null,Validators.required),
      'salary':new FormControl(null,Validators.required)
    })
   
    if(this.empservice.tempId!=0){
      this.updatactive=true;
      
      this.EmployeeForms.patchValue({
        'id':this.empservice.tempEmployee.id,
        'name':this.empservice.tempEmployee.name,
        'sex':this.empservice.tempEmployee.sex,
        'address':this.empservice.tempEmployee.address,
        'maritalstatus':this.empservice.tempEmployee.maritalstatus,
        'department':this.empservice.tempEmployee.department,
        'salary':this.empservice.tempEmployee.salary

      })
    }
  }

  
onView()
{
  this.route.navigate(['view']);
}
onSubmit()
{
this.empservice.createEmployee(this.EmployeeForms.value).subscribe();
 this.route.navigate(['view']);

}
onCancel(){
  this.EmployeeForms.reset();
  this.route.navigate(['view']);
 
}
onUpdate(){
  this.EmployeeForms.value.empid=this.empservice.tempId;
  console.log(this.EmployeeForms.value);
  this.empservice.putEmployee(this.EmployeeForms.value).subscribe();
  this.empservice.tempId=0;
  this.updatactive=false;
  this.route.navigate(['view']);
}
}
