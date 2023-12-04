import { FuncionarioCargo } from "./FuncionarioCargo";

export class Funcionario {
    Id : number;
    Nome : string;
    Idade : number;
    DocFederal : string;
    TipoPessoa : number;
    Email : string;
    Telefone : string;
    Ativo: boolean;
    FuncionarioCargo: FuncionarioCargo[]
}