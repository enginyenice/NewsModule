import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewsModel } from './models/news-model';
import { Observable } from 'rxjs';
import { CreateNewsModel } from './models/create-news-model';
import { UpdateNewsModel } from './models/update-news-model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NewsService {
  
  private baseURL: string = `${environment.domain}/News`;
  constructor(private http: HttpClient) { }

  getAll() : Observable<NewsModel[]> {
    var url = `${this.baseURL}`
    return this.http.get<NewsModel[]>(url);
  }
  get(id:number): Observable<NewsModel> {
    var url = `${this.baseURL}/${id}`
    return this.http.get<NewsModel>(url);
  }
  create(createNewsModel : CreateNewsModel) {
    var url = `${this.baseURL}`
    return this.http.post<NewsModel[]>(url,createNewsModel);
  }
  delete(id: number){
    var url = `${this.baseURL}?id=${id}`;
    return this.http.delete(url);
  }
  update(updateNewsMode: UpdateNewsModel,id: number){
    var url = `${this.baseURL}/${id}`;
    return this.http.put(url,updateNewsMode);
  }
  
  
}
