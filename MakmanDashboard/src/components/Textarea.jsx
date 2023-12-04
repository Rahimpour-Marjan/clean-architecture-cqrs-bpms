import styled from 'styled-components';
import { Input } from './Input';

const TextareaStyled = styled(Input)`
  height: 8rem;
`;

export const Textarea = props => {
  return (
    <TextareaStyled
      as='textarea'
      {...props}
      {...props.register(props.label, {
        required: 'This field is required',
      })}
      disabled={props.disabled}
    />
  );
};
