import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { response } from 'express';
import { observable } from 'rxjs';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-eventos',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule],
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss'
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  widthImg: number = 50;
  marginImg: number = 2;
  imagemVisivel: boolean = true;
  filtroLista: string = '';

  constructor(private http: HttpClient){  }

  ngOnInit(): void {
      this.getEventos();
  }

  mostrarImagem(){
    this.imagemVisivel = !this.imagemVisivel;
  }

  public getEventos(): void{
    this.http.get('https://localhost:5001/api/eventos').subscribe((data) => {
      console.log(data);
      this.eventos = data;
    }
    );
    
  }
}
