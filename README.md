# FCG_User_Notification
Azure Function responsável por notificar usuários sobre seu cadastro na plataforma.
A função envia e-mails de boas-vindas/notificação via SMTP e está atualmente configurada para rodar em um container Docker hospedado em uma instância EC2 (AWS).

## Tecnologias utilizadas
 - C# / .NET
 - Azure Functions
 - SMTP (System.Net.Mail) para envio de e-mails
 - Docker (empacotamento e execução)
 - AWS EC2 (hospedagem do container)

## Objetivo
Garantir que todo usuário recém-cadastrado receba uma notificação automática por e-mail, confirmando seu cadastro e fornecendo informações iniciais da plataforma.

##🔮 Possíveis Extensões Futuras
 - Suporte a múltiplos provedores de e-mail
 - Retentativas automáticas em caso de falha
 - Templates HTML para e-mails (personalização por idioma)
 - Migração futura para o Amazon SES como provedor principal de envio de e-mails
