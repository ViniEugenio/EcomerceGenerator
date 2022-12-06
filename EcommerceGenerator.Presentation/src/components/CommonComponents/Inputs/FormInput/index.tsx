import { Container, Input, Label } from "./style";

interface FormInputProps {

    Type: string;
    TextLabel: string;
    Heigth: number;
    Width: number;    

}

export function FormInput({Type,TextLabel, Heigth, Width}: FormInputProps){

    return(

        <Container>

            <Label>{TextLabel}</Label>
            <Input Heigth={Heigth}
            Width={Width}
            type={Type}></Input>

        </Container>

    )

}