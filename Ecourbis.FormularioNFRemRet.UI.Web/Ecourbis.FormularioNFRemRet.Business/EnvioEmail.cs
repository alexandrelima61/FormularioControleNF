using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ecourbis.FormularioNFRemRet.Model;
using System.Net.Mail;
using System.IO;

namespace Ecourbis.FormularioNFRemRet.Business
{
    public class EnvioEmail
    {
        public void carregaHtml(HeaderForMOD heaader, List<ProdutMOD> acolsP)
        {
            //string cHtml = "";
            string cHtml = "";//new StreamWriter(@"C:\jalima\" + heaader.numControl.ToString("000000") + heaader.user + ".html");
            Utilitario util = new Utilitario();

            cHtml += "<!DOCTYPE html>\n";
            cHtml += "<html xmlns='http://www.w3.org/1999/xhtml'>\n";
            cHtml += "<head>\n";
            cHtml += "    <meta charset='iso-8859-1' />\n";
            cHtml += "    <title>Solicitação de Nota Fiscal de Remessa ou Retorno</title>\n";
            cHtml += "    <!--<link rel='stylesheet' href='http://cam.ecourbis.com.br/web/imagens/bootstrap.minjl.css' />\n";
            cHtml += "    <script src='http://http://cam.ecourbis.com.br/web/imagens/bootstrap.minjl.js'></script>-->\n";
            cHtml += "    <style>\n";
            cHtml += "        .principal {\n";
            cHtml += "            padding: 20px 10px;\n";
            cHtml += "        }\n";
            cHtml += "\n";
            cHtml += "        .rotulo {\n";
            cHtml += "            font-weight: bold;\n";
            cHtml += "            font-family: Arial,Tahoma,'Segoe UI';\n";
            cHtml += "            font-size: 13px;\n";
            cHtml += "        }\n";
            cHtml += "\n";
            cHtml += "        .informativo {\n";
            cHtml += "            font-weight: normal;\n";
            cHtml += "            font-family: Arial,Tahoma,'Segoe UI';\n";
            cHtml += "            font-size: 12px;\n";
            cHtml += "            color: #033dfc;\n";
            cHtml += "        }\n";
            cHtml += "\n";
            cHtml += "        .text-center {\n";
            cHtml += "            text-align: center;\n";
            cHtml += "        }\n";
            cHtml += "\n";
            cHtml += "        .text-left {\n";
            cHtml += "            text-align: left;\n";
            cHtml += "        }\n";
            cHtml += "\n";
            cHtml += "        .banner-dtPrazo {\n";
            cHtml += "            font-weight: bold;\n";
            cHtml += "            color: #ff0000;\n";
            cHtml += "        }\n";
            cHtml += "\n";
            cHtml += "        .alert-success {\n";
            cHtml += "            background-color: #82d29e;\n";
            cHtml += "            border: solid 1px #d0cece;\n";
            cHtml += "            color: #fff;\n";
            cHtml += "        }\n";
            cHtml += "\n";
            cHtml += "\n";
            cHtml += "        .csshr {\n";
            cHtml += "            border-top: 1px solid #808080;\n";
            cHtml += "        }\n";
            cHtml += "    </style>\n";
            cHtml += "</head>\n";
            cHtml += "<body>\n";
            cHtml += "    <div class='container principal'>\n";
            cHtml += "        <table style='border: solid 1px #808080;'>\n";
            cHtml += "            <tbody>\n";
            cHtml += "                <tr>\n";
            cHtml += "                    <td>\n";
            cHtml += "                        <div class='col-lg-2'>\n";
            cHtml += "                            <img src='http://cam.ecourbis.com.br/web/imagens/top-logo.png' />\n";
            cHtml += "                        </div>\n";
            cHtml += "                    </td>\n";
            cHtml += "                    <td colspan='3'>\n";
            cHtml += "                        <table>\n";
            cHtml += "                            <tbody>\n";
            cHtml += "                                <tr>\n";
            cHtml += "                                    <td colspan='2'>\n";
            cHtml += "                                        <div class='text-center rotulo'>\n";
            cHtml += "                                            <p>FORMULÁRIO DE SOLICITAÇÃO DE NOTA FISCAL DE REMESSA OU RETORNO DE BENS EM GERAL E DE CONTROLE DE RECEBIMENTO DE BENS DE TERCEIROS</p>\n";
            cHtml += "                                        </div>\n";
            cHtml += "                                    </td>\n";
            cHtml += "                                </tr>\n";
            cHtml += "                                <tr>\n";
            cHtml += "                                    <td>\n";
            cHtml += "                                        <div class='text-center'>\n";
            cHtml += "                                            <span class='rotulo'>Data da Solicitação: </span>&nbsp;<span class='informativo'>" + heaader.dtSolicit.ToString("dd/MM/yyyy") + "</span>\n";
            cHtml += "                                        </div>\n";
            cHtml += "                                    </td>\n";
            cHtml += "                                    <td>\n";
            cHtml += "                                        <div class='text-center banner-dtPrazo'>\n";
            cHtml += "                                            <span class='rotulo banner-dtPrazo'>Prazo previsto para o Retorno: </span>&nbsp;<span class='rotulo banner-dtPrazo'>" + heaader.prazo.ToString("dd/MM/yyyy") + "</span>\n";
            cHtml += "                                        </div>\n";
            cHtml += "                                    </td>\n";
            cHtml += "                                </tr>\n";
            cHtml += "                            </tbody>\n";
            cHtml += "                        </table>\n";
            cHtml += "                    </td>\n";
            cHtml += "                </tr>\n";
            cHtml += "                <tr>\n";
            cHtml += "                    <td class='csshr'>\n";
            cHtml += "                        <table>\n";
            cHtml += "                            <tbody>\n";
            cHtml += "                                <tr>\n";
            cHtml += "                                    <td class='text-center'>\n";
            cHtml += "                                        <div class='text-center'>\n";
            cHtml += "                                            <span class='rotulo'>Retirada</span>\n";
            cHtml += "                                            <hr class='csshr' />\n";
            cHtml += "                                        </div>\n";
            cHtml += "                                    </td>\n";
            cHtml += "                                </tr>\n";
            cHtml += "                                <tr>\n";
            cHtml += "                                    <td class='text-left'>\n";
            cHtml += "                                        <div class='text-left informativo'>\n";
            cHtml += heaader.retirada == "1" ? " <input type='radio' name='ret' value='1' checked='checked' disabled='disabled'/>&nbsp;Almoxarifado<br>\n" : " <input type='radio' name='vehicle' value='1' disabled='disabled'/>&nbsp;<label class='rotulo'>Almoxarifado</label><br>\n";
            cHtml += heaader.retirada == "2" ? " <input type='radio' name='ret' value='2' checked='checked' disabled='disabled'/>&nbsp;Solicitante<br>\n" : "<input type='radio' name='vehicle' value='2'  disabled='disabled'/>&nbsp;<label class='rotulo'>Solicitante</label><br>\n";
            cHtml += "                                            <br />\n";
            cHtml += "                                            <br />\n";
            cHtml += "                                            <br />\n";
            cHtml += "                                            <br />\n";
            cHtml += "                                            <br />\n";
            cHtml += "                                        </div>\n";
            cHtml += "                                    </td>\n";
            cHtml += "                                </tr>\n";
            cHtml += "                            </tbody>\n";
            cHtml += "                        </table>\n";
            cHtml += "                    </td>\n";
            cHtml += "                    <td class='csshr'>\n";
            cHtml += "                        <table>\n";
            cHtml += "                            <tbody>\n";
            cHtml += "                                <tr style='width:100%;'>\n";
            cHtml += "                                    <td class='text-center'>\n";
            cHtml += "                                        <div class='text-center rotulo'>\n";
            cHtml += "                                            <span class='rotulo'>Unidade</span>\n";
            cHtml += "                                            <hr class='csshr' />\n";
            cHtml += "                                        </div>\n";
            cHtml += "                                    </td>\n";
            cHtml += "                                </tr>\n";
            cHtml += "                                <tr>\n";
            cHtml += "                                    <td class='text-left'>\n";
            cHtml += "                                        <div class='text-left informativo'>\n";
            cHtml += "                                            <span>\n";
            cHtml += heaader.unidade == "1" ? " <input type='radio' name='uni' value='1' checked='checked' disabled='disabled'/>&nbsp;<label class='rotulo'>Sul</label><br>\n" : " <input type='radio' name='vehicle' value='1' disabled='disabled'/>&nbsp;<label class='rotulo'>Sul</label><br>\n";
            cHtml += heaader.unidade == "2" ? " <input type='radio' name='uni' value='2' checked='checked'disabled='disabled'/>&nbsp;<label class='rotulo'>Leste</label><br>\n" : " <input type='radio' name='vehicle' value='1' disabled='disabled'/>&nbsp;<label class='rotulo'>Leste</label><br>\n";
            cHtml += heaader.unidade == "3" ? " <input type='radio' name='uni' value='3' checked='checked' disabled='disabled'/>&nbsp;<label class='rotulo'>Transb. Sto. Amaro</label><br>\n" : " <input type='radio' name='vehicle' value='1' disabled='disabled'/>&nbsp;<label class='rotulo'>Transb. Sto. Amaro</label><br>\n";
            cHtml += heaader.unidade == "4" ? " <input type='radio' name='uni' value='4' checked='checked' disabled='disabled'/>&nbsp;<label class='rotulo'>Transb. Vergueiro</label><br>\n" : " <input type='radio' name='vehicle' value='1' disabled='disabled'/>&nbsp;<label class='rotulo'>Transb. Vergueiro</label><br>\n";
            cHtml += heaader.unidade == "5" ? " <input type='radio' name='uni' value='5' checked='checked' disabled='disabled'/>&nbsp;<label class='rotulo'>Central Mecan. Triagem</label><br>\n" : " <input type='radio' name='vehicle' value='1' disabled='disabled'/>&nbsp;<label class='rotulo'>Central Mecan. Triagem</label><br>\n";
            cHtml += heaader.unidade == "6" ? " <input type='radio' name='uni' value='6' checked='checked' disabled='disabled'/>&nbsp;<label class='rotulo'>Aterro CTL</label><br>\n" : " <input type='radio' name='vehicle' value='1' disabled='disabled'/>&nbsp;<label class='rotulo'>Aterro CTL</label><br>\n";
            cHtml += "                                            </span>\n";
            cHtml += "                                        </div>\n";
            cHtml += "                                    </td>\n";
            cHtml += "                                </tr>\n";
            cHtml += "                            </tbody>\n";
            cHtml += "                        </table>\n";
            cHtml += "                    </td>\n";
            cHtml += "                    <td class='csshr'>\n";
            cHtml += "                        <table>\n";
            cHtml += "                            <tbody>\n";
            cHtml += "                                <tr style='width:100%;'>\n";
            cHtml += "                                    <td class='text-center'>\n";
            cHtml += "                                        <div class='text-center'>\n";
            cHtml += "                                            <span class='rotulo'>Dados do Solicitante</span>\n";
            cHtml += "                                            <hr class='csshr' />\n";
            cHtml += "                                        </div>\n";
            cHtml += "                                    </td>\n";
            cHtml += "                                </tr>\n";
            cHtml += "                                <tr>\n";
            cHtml += "                                    <td class='text-left'>\n";
            cHtml += "                                        <div class='text-left'>\n";
            cHtml += "                                            <span>\n";
            cHtml += "                                                <span class='rotulo'>Nome:</span>&nbsp;<span class='informativo'> " + heaader.numUser.Trim() + "</span>   <br /><br />\n";
            cHtml += "                                                <span class='rotulo'>Depart:</span>&nbsp;<span class='informativo'>" + heaader.depUser.Trim() + "</span>   <br /><br />\n";
            cHtml += "                                                <span class='rotulo'>Função:</span>&nbsp;<span class='informativo'>" + heaader.funUSer.Trim() + "</span>   <br /><br />\n";
            cHtml += "                                            </span>\n";
            cHtml += "                                        </div>\n";
            cHtml += "                                    </td>\n";
            cHtml += "                                </tr>\n";
            cHtml += "                            </tbody>\n";
            cHtml += "                        </table>\n";
            cHtml += "                    </td>\n";
            cHtml += "                    <td class='csshr' style='text-align:right;'>\n";
            cHtml += "                        <table>\n";
            cHtml += "                            <tbody>\n";
            cHtml += "                                <tr style='width:100%;'>\n";
            cHtml += "                                    <td class='text-center'>\n";
            cHtml += "                                        <div class='text-center rotulo'>\n";
            cHtml += "                                            <span class='rotulo'>Tipo do Controle</span>\n";
            cHtml += "                                            <hr class='csshr' />\n";
            cHtml += "                                        </div>\n";
            cHtml += "                                    </td>\n";
            cHtml += "                                </tr>\n";
            cHtml += "                                <tr>\n";
            cHtml += "                                    <td class='text-left'>\n";
            cHtml += "                                        <div class='text-left informativo'>\n";
            cHtml += "                                            <span>\n";
            cHtml += heaader.tipo == "1" ? " <input type='radio' name='vehicle' value='1' checked='checked' disabled='disabled'/>&nbsp;<label class='rotulo'>Nota Fiscal de Remessa</label><br />\n" : "<input type='radio' name='vehicle' value='1' disabled='disabled'/>&nbsp;<label class='rotulo'>Nota Fiscal de Remessa</label><br />\n";
            cHtml += heaader.tipo == "2" ? " <input type='radio' name='vehicle' value='2' checked='checked' disabled='disabled'/>&nbsp;<label class='rotulo'>Receb. de Bem de Terceiros</label><br />\n" : "<input type='radio' name='vehicle' value='2' disabled='disabled'/>&nbsp;<label class='rotulo'>Receb. de Bem de Terceiros</label><br />\n";
            cHtml += heaader.tipo == "3" ? " <input type='radio' name='vehicle' value='3' checked='checked' disabled='disabled'/>&nbsp;<label class='rotulo'>Nota Fiscal de Terceiro</label><br />\n" : "<input type='radio' name='vehicle' value='3' disabled='disabled'/>&nbsp;<label class='rotulo'>Nota Fiscal de Terceiro</label><br />\n";
            cHtml += "                                            </span>\n";
            cHtml += "                                            <br />\n";
            cHtml += "\n";
            cHtml += "                                            <div style='margin-left:10px;'>\n";
            cHtml += "                                                <span class='rotulo'>NF de Origem:</span>\n";
            cHtml += "                                                <span class='informativo'>" + heaader.nfOrigem.Trim() + "</span>\n";
            cHtml += "                                            </div>\n";
            cHtml += "\n";
            cHtml += "                                            <br />\n";
            cHtml += "                                            <br />\n";
            cHtml += "                                            <br />\n";
            cHtml += "                                        </div>\n";
            cHtml += "                                    </td>\n";
            cHtml += "                                </tr>\n";
            cHtml += "                            </tbody>\n";
            cHtml += "                        </table>\n";
            cHtml += "                    </td>\n";
            cHtml += "                </tr>\n";
            cHtml += "                <tr style='padding:5px 5px;'>\n";
            cHtml += "                    <td class='csshr text-left'>\n";
            cHtml += "                        <br />\n";
            cHtml += "                        <span class='rotulo'>Codigo:</span>&nbsp;&nbsp;<span class='informativo'>" + heaader.codCliFor.Trim() + "</span>\n";
            cHtml += "                    </td>\n";
            cHtml += "                    <td class='csshr text-left' colspan='2'>\n";
            cHtml += "                        <br />\n";
            cHtml += "                        <span class='rotulo'>Razão Social:</span>&nbsp;&nbsp;<span class='informativo'>" + heaader.nomeCliFor.Trim() + "</span>\n";
            cHtml += "                    </td>\n";
            cHtml += "                    <td class='csshr'>\n";
            cHtml += "                        <br />\n";
            cHtml += "                        <span class='rotulo'>Loja:</span>&nbsp;&nbsp;<span class='informativo'>" + heaader.loja.Trim() + "</span>\n";
            cHtml += "                    </td>\n";
            cHtml += "                </tr>\n";
            cHtml += "                <tr style='padding:5px 5px;'>\n";
            cHtml += "                    <td class='csshr text-left' colspan='2'>\n";
            cHtml += "                        <br />\n";
            cHtml += "                        <span class='rotulo'>Endereço:</span>&nbsp;&nbsp;<span class='informativo'>" + heaader.endereco.Trim() + "</span>\n";
            cHtml += "                    </td>\n";
            cHtml += "                    <td class='csshr text-left' colspan='2'>\n";
            cHtml += "                        <br />\n";
            cHtml += "                        <span class='rotulo'>Email:</span>&nbsp;&nbsp;<span class='informativo'>" + heaader.email.Trim() + "</span>\n";
            cHtml += "                    </td>\n";
            cHtml += "                </tr>\n";
            cHtml += "                <tr style='padding:5px 5px;'>\n";
            cHtml += "                    <td class='csshr text-left' colspan='2'>\n";
            cHtml += "                        <br />\n";
            cHtml += "                        <span class='rotulo'>Telefone:</span>&nbsp;&nbsp;<span class='informativo'>" + heaader.telefone.Trim() + "</span>\n";
            cHtml += "                    </td>\n";
            cHtml += "                    <td class='csshr text-left' colspan='2'>\n";
            cHtml += "                        <br />\n";
            cHtml += "                        <span class='rotulo'>CNPJ:</span>&nbsp;&nbsp;<span class='informativo'>" + util.masckDados(heaader.cnpj.Trim(), 2) + "</span>\n";
            cHtml += "                    </td>\n";
            cHtml += "                </tr>\n";
            cHtml += "                <tr>\n";
            cHtml += "                    <td colspan='4' class='csshr'>\n";
            cHtml += "                        <br />\n";
            cHtml += "                        <table class='table table-responsive' style='width:99.8%;'>\n";
            cHtml += "                            <thead>\n";
            cHtml += "                                <tr style='border: solid 1px #d0cece; '>\n";
            cHtml += "                                    <th class='alert-success'>Item</th>\n";
            cHtml += "                                    <th class='alert-success'>Código</th>\n";
            cHtml += "                                    <th class='alert-success'>Descrição</th>\n";
            cHtml += "                                    <th class='alert-success'>Und. Méd.</th>\n";
            cHtml += "                                    <th class='alert-success'>Quant.</th>\n";
            cHtml += "                                    <th class='alert-success'>Controle</th>\n";
            cHtml += "                                    <th class='alert-success'>Prazo Ret.</th>\n";
            cHtml += "                                </tr>\n";
            cHtml += "                            </thead>\n";

            if (acolsP.Count > 0)
            {
                foreach (var item in acolsP)
                {
                    cHtml += "                        <tr class='informativo'>\n";
                    cHtml += "                            <td style='border-bottom: solid 1px #808080;'>" + item.Item.ToString("000") + "</td>\n";
                    cHtml += "                            <td style='border-bottom: solid 1px #808080;'>" + item.Codigo.Trim() + "</td>\n";
                    cHtml += "                            <td style='border-bottom: solid 1px #808080;'>" + item.Descricao.Trim() + "</td>\n";
                    cHtml += "                            <td style='border-bottom: solid 1px #808080;'>" + item.UnidMedida.Trim() + "</td>\n";
                    cHtml += "                            <td style='border-bottom: solid 1px #808080;'>" + item.Quantidade.Trim() + "</td>\n";
                    cHtml += "                            <td style='border-bottom: solid 1px #808080;'>" + item.Controle + "</td>\n";
                    cHtml += "                            <td style='border-bottom: solid 1px #808080;'>" + item.prazoRetorno + "</td>\n";
                    cHtml += "                        </tr>\n";
                }
            }
            cHtml += "                        </table>\n";
            cHtml += "                        <br />\n";
            cHtml += "                    </td>\n";
            cHtml += "                </tr>\n";
            cHtml += "                <tr>\n";
            cHtml += "                    <td colspan='4' class='csshr rotulo text-center'>\n";
            cHtml += "                        <br />\n";
            cHtml += "                        <span class='rotulo text-center'>RECB. DE BEM DE TERCEUROS</span>\n";
            cHtml += "                    </td>\n";
            cHtml += "                </tr>\n";
            cHtml += "                <tr>\n";
            cHtml += "                    <td class='text-center csshr rotulo' colspan='4'>\n";
            cHtml += "                        <br />\n";
            cHtml += "                        <table style='width:98%'>\n";
            cHtml += "                            <tr class='text-center csshr rotulo'>\n";

            if (heaader.tipo.Equals("1"))
            {
                cHtml += "                                <td>\n";
                cHtml += heaader.nfRem == "1" ? " <input type='radio' id='rdbConcertoRem' name='tipo' checked='checked' disabled='disabled'/>&nbsp;<label>Concerto</label>\n" : "<input id='rdbConcertoRem' name='tipo' disabled='disabled' type='radio'/> &nbsp;<label class='rotulo'>Concerto</label>\n";
                cHtml += "                                </td>\n";
                cHtml += "                                <td>\n";
                cHtml += heaader.nfRem == "2" ? "  <input type='radio' id='rdbBenefRem' name='tipo' checked='checked' disabled='disabled'/>&nbsp;<label>Beneficiamento</label>\n" : "<input id='rdbBenefRem' name='tipo' disabled='disabled' type='radio'/> &nbsp;<label class='rotulo'>Beneficiamento</label>\n";
                cHtml += "                                </td>\n";
                cHtml += "                                <td>\n";
                cHtml += heaader.nfRem == "3" ? "<input type='radio' id='rdbOutRem' name='tipo' checked='checked' disabled='disabled'/>&nbsp;<label>Outros: especificar</label>\n" : "<input id='rdbOutRem' disabled='disabled' name='tipo' type='radio'/> &nbsp;<label class='rotulo'>Outros: especificar</label>\n";
                cHtml += "                                </td>\n";

            }
            else if (heaader.tipo.Equals("2"))
            {
                cHtml += "                                <td>\n";
                cHtml += heaader.nfTerc == "1" ? " <input type='radio' id='rddLocTer' type='radio' name='tipo' value='rddLocTer' checked='checked' disabled='disabled'/>&nbsp;<label>Locação</label>\n" : "<input id='rddLocTer' type='radio' name='tipo' disabled='disabled' value='rddLocTer'/>&nbsp;<label class='rotulo'>Locação</label>\n";
                cHtml += "                                </td>\n";
                cHtml += "                                <td>\n";
                cHtml += heaader.nfTerc == "2" ? "<input type='radio' id='rdbEmpTer' type='radio' name='tipo' value='rdbEmpTer'checked='checked' disabled='disabled'/>&nbsp;<label>Empréstimo</label>\n" : "<input id='rdbEmpTer' type='radio' name='tipo' disabled='disabled' value='rdbEmpTer' />&nbsp;<label class='rotulo'>Empréstimo</label>\n";
                cHtml += "                                </td>\n";
                cHtml += "                                <td>\n";
                cHtml += heaader.nfTerc == "3" ? " <input type='radio' id='rdbOutTer' type='radio' name='tipo' value='rdbOutTer' checked='checked' disabled='disabled'/>&nbsp;<label>Outros: especificar</label>\n" : "<input id='rdbOutTer' type='radio' disabled='disabled' name='tipo' value='rdbOutTer' />&nbsp;<label class='rotulo'>Outros: especificar</label>\n";
                cHtml += "                                </td>\n";

            }
            else if (heaader.tipo.Equals("3"))
            {
                cHtml += "                                <td>\n";
                cHtml += heaader.nfRet == "1" ? " <input type='radio' id='rdbLocRet' name='tipo' checked='checked' disabled='disabled'/>&nbsp;<label>Locação</label>\n" : "<input id='rdbLocRet' type='radio' name='tipo' value='rddLocTer' disabled='disabled'/>&nbsp;<label class='rotulo'>Locação</label>\n";
                cHtml += "                                </td>\n";
                cHtml += "                                <td>\n";
                cHtml += heaader.nfRet == "2" ? " <input type='radio' id='rdbEmpRet' name='tipo' checked='checked' disabled='disabled'/>&nbsp;<label>Empréstimo</label>\n" : "<input id='rdbEmpRet' type='radio' name='tipo' value='rdbEmpTer' disabled='disabled'/>&nbsp;<label class='rotulo'>Empréstimo</label>\n";
                cHtml += "                                </td>\n";
                cHtml += "                                <td>\n";
                cHtml += heaader.nfRet == "3" ? " <input type='radio' id='rdbOutRet' name='tipo' checked='checked' disabled='disabled'/>&nbsp;<label>Outros: especificar</label>\n" : "<input id='rdbOutRet' type='radio' name='tipo' disabled='disabled' value='rdbEmpTer' />&nbsp;<label class='rotulo'>Outros: especificar</label>\n";
                cHtml += "                                </td>\n";

            }
            cHtml += "                            </tr>\n";
            cHtml += "                            <tr class='text-center csshr rotulo'>\n";
            cHtml += "                                <td colspan='3' class='text-center csshr informativo'>\n";
            cHtml += "                                    <br />\n";
            cHtml += "                                    <p class='text-center csshr informativo'>" + heaader.justificativa.Trim() + "</p>\n";
            cHtml += "                                </td>\n";
            cHtml += "                            </tr>\n";
            cHtml += "                        </table>\n";
            cHtml += "                    </td>\n";
            cHtml += "                </tr>\n";
            cHtml += "            </tbody>\n";
            cHtml += "        </table>\n";
            cHtml += "    </div>\n";
            cHtml += "</body>\n";
            cHtml += "</html>\n";

            SendMail("Email Teste", cHtml.ToString());

        }

        //envia e-mail
        public static void SendMail(string assunto, string cmsg)
        {
            //Cria os objetos da classe de e-mail
            using (SmtpClient smtp = new SmtpClient())
            {
                using (MailMessage msg = new MailMessage())
                {
                    try
                    {
                        MailAddress xFrom = new MailAddress("workflow@ecourbis.com.br", "Workflow Ecourbis");
                        msg.From = xFrom;

                        MailAddress x_wsilva = new MailAddress("jalima@ecourbis.com.br", "J. Alexandre de Lima");
                        msg.To.Add(x_wsilva);

                        //for (int x = 0; x < nomesEmail.Length - (nomesEmail.Length / 2); x++)
                        //{
                        //    MailAddress xPara = new MailAddress(nomesEmail[x, 0].Trim() + "@ecourbis.com.br", nomesEmail[x, 1].Trim());
                        //    msg.To.Add(xPara);
                        //}

                        msg.Subject = assunto;
                        msg.IsBodyHtml = true;
                        msg.Body = cmsg;
                        smtp.Host = "ssuv-42";


                        smtp.Send(msg);
                    }
                    catch (Exception)
                    {
                    }

                }
            }
        }

    }
}
