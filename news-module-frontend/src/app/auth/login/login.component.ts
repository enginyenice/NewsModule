import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AuthService } from '../auth.service';
import { LoginModel } from '../models/login-model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  constructor(private formBuilder: FormBuilder, private authService : AuthService,private router : Router) { }
  public loginForm!: FormGroup;
  ngOnInit(): void {
    this.createForm();
  }
  
  createForm(){
    this.loginForm = this.formBuilder.group({
      email: '',
      password: ''
    })
  }
  public login(){
    let loginModel = Object.assign({}, this.loginForm.value);
    this.authService.login(loginModel).subscribe({
      next: (response) => {
        localStorage.setItem("token",response.token)
        this.router.navigate(['news']);
      },
      error: (response) => {
        console.log(response.error.Message)
      }
    });
  }
}
