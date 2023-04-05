import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NewsService } from '../news.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  createNewsForm!: FormGroup;
constructor(private formBuilder:FormBuilder, private newsService: NewsService,private router :Router){}
  ngOnInit(): void {
    this.createForm();
  }
  createForm(){
    this.createNewsForm = this.formBuilder.group({
      title: '',
      description: ''
    })
  }
  create(){
    let newsModel = Object.assign({}, this.createNewsForm.value);
    this.newsService.create(newsModel).subscribe({
      next: (response) => {
        this.router.navigate(["news"]);
      },
      error: (response) => {
        console.log(response.error.Message)
      }
    });
  }
}
