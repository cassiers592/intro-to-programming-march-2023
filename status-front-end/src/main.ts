import './style.css'

const button = document.querySelector('#btn') as HTMLButtonElement;

if(button === null)
{
    console.error("Could not find button");
}
else
{
    button.addEventListener('click', ()=> {
        fetch('http://localhost:1337/status')
        .then(response => response.json())
        .then((status:ResponseMessage) => {
            console.log(`The status is ${status.message} as of ${status.when}`)
        });
    });
}

type ResponseMessage = {
    id: string;
    message: string;
    when: string;
}