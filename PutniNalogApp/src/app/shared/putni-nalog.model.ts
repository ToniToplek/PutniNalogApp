export class PutniNalog {
    idPutniNalog:number=0;
    razlogPutovanja:string='';
    vrijemePolazak:Date = new Date();
    vrijemePovratak:Date= new Date();
    komentar:string='';
    email:string='';
    kmPocetak:number=0;
    kmZavrsetak:number=0;
    auti:Auto;
    lokacijePolaziste: Lokacija;
    lokacijeOdrediste: Lokacija;
    korisniciNalogs:KorisniciNalog;
    trosakNalogs:TrosakNalog;
}

export class Auto{
    idAuto:number=0;
    registracijaAuta:string='';
    markaAuta:string='';
    nazivAuta:string='';
    kilometraza:number=0;
    vrstaPrijevoza:number=0;
    putniNalogs:PutniNalog;
}

export class Lokacija{
    idLokacija:number=0;
    naziv:string='';
    putniNalogs:PutniNalog;
}

export class Korisnici{
    idKorisnik:number=0;
    imeKorisnik:string='';
    prezimeKorisnik:string='';
    korisniciNalogs:KorisniciNalog;
}

export class KorisniciNalog{
    idKorisniciNalog:number=0;
    korisnik:Korisnici;
    putniNalog:PutniNalog
}

export class Triskovi{
    idTrosak:number=0;
    opisTroska:string='';
    iznos:number=0;
    trosakNalogs:TrosakNalog;
}
export class TrosakNalog{
    idTrosakNalog:number=0;
    trosak:Triskovi;
    putniNalog:PutniNalog
}