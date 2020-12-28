export class PutniNalog {
    idPutniNalog:number=0;
    razlogPutovanja:string='';
    vrijemePolazak:Date = new Date();
    vrijemePovratak:Date= new Date();
    komentar:string='';
    email:string='';
    kmPocetak:number=0;
    kmZavrsetak:number=0;
    idAuto:number=0;
    auti:Auto;
    idPolaziste:number=0;
    lokacijePolaziste: Lokacija;
    idOdrediste:number=0;
    lokacijeOdrediste: Lokacija;
}

export class Auto{
    idAuto:number=0;
    registracijaAuta:string='';
    markaAuta:string='';
    nazivAuta:string='';
    kilometraza:number=0;
    vrstaPrijevoza:number=0;
}

export class Lokacija{
    idLokacija:number=0;
    naziv:string='';
}

export class Korisnici{
    idKorisnik:number=0;
    imeKorisnik:string='';
    prezimeKorisnik:string='';
}

export class KorisniciNalog{
    idKorisniciNalog:number=0;
    idKorisnik:number=0;
    korisnik:Korisnici;
    idPutniNalog:number=0;
    putniNalog:PutniNalog;
}

export class Triskovi{
    idTrosak:number=0;
    opisTroska:string='';
    iznos:number=0;
    idPutniNalog:number=0;
    putniNalog:PutniNalog;
}
