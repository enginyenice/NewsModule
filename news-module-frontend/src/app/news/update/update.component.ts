import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NewsService } from '../news.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NewsModel } from '../models/news-model';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  constructor(private formBuilder: FormBuilder, private newsService: NewsService, private router: Router, private activatedRoute: ActivatedRoute) { }
  id: number = 0;
  updateNewsForm!: FormGroup;
  ngOnInit(): void {
    this.createUpdateForm();
    this.activatedRoute.params.subscribe(params => {
      this.id = params['id'];
      this.getNews(this.id)
    });

  }

  createUpdateForm(){
    this.updateNewsForm = this.formBuilder.group({
      title: '',
      description: ''
    })
  }
  getNews(id: number) {
    this.newsService.get(id).subscribe({
      next: (response) => {
        this.updateNewsForm.patchValue({
          title: response.title,
          description: response.description
        })
      },
      error: (error) => {
        console.log(error.error.Message);
      }
    })
  }


  update(){
    let newsUpdateModel = Object.assign({}, this.updateNewsForm.value);

    this.newsService.update(newsUpdateModel,this.id).subscribe({
      next: (response) => {
        this.router.navigate(["news"]);
      },
      error: (response) => {
        console.log(response.error.Message)
      }
    });
  }
}
