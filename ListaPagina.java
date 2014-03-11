package sistemaoperativo;

public class ListaPagina {
    private Pagina pagina;
    
//    public ListaPagina(){
//        
//    }
    
    public void setPagina(int numero, int residencia, int llegada, int acceso, int NURlectura, int NURescritura, int modificacion){
        if(pagina == null) {
            pagina = new Pagina(numero, residencia, llegada, acceso, NURlectura, NURescritura, modificacion);
        } 
        else {
            Pagina nuevaPagina = new Pagina(numero, residencia, llegada, acceso, NURlectura, NURescritura, modificacion);   
            Pagina aux = new Pagina();
            aux = pagina;
            
            while(aux.getNextPagina() != null){
                aux = aux.getNextPagina();
            }
            aux.setNextPagina(nuevaPagina);
            //pagina = aux;  
        }
    }
    
    public Pagina getPagina(){
        return pagina;
    }
}