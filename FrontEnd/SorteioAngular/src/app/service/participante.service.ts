import { Injectable } from "@angular/core";
import { HttpParams, HttpClient } from '@angular/common/http';
import { Participante } from "../models/participante";
import { Observable } from "rxjs";


@Injectable({
    providedIn: 'root'
})
export class ParticipantesService {

    private url = "https:localhost:44334/api/participantes/"
    constructor(private http: HttpClient) { }

    obterParticipantesIdosos(): Observable<Participante[]>  {
        return this.http.get<Participante[]>(this.url + "obterIdosos");
    }

    obterParticipantesComDeficienciaFisica(): Observable<Participante[]>  {
        return this.http.get<Participante[]>(this.url + "obterDeficientesFisico");
    }

    obterParticipantesGeral(): Observable<Participante[]>  {
        return this.http.get<Participante[]>(this.url + "obterGerais");
    }

    realizarSorteio(): Observable<Participante[]>  {
        return this.http.get<Participante[]>(this.url + "realizarSorteio");
    }
    
}