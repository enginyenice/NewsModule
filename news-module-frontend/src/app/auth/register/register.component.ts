import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{
  constructor(private formBuilder: FormBuilder,private authService: AuthService,private router : Router) {}
  registerForm!: FormGroup;
  ngOnInit(): void {
    this.createForm()
  }

  createForm(){
    this.registerForm = this.formBuilder.group({
      email: '',
      password: ''
    })
  }
  public register(){
    let registerModel = Object.assign({}, this.registerForm.value);
    this.authService.register(registerModel).subscribe({
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
