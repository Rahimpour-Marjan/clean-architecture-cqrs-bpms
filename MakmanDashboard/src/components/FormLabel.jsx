import styled from 'styled-components';

const FormLabelStyled = styled.p`
  color: var(--grey-500);
  font-size: 36px;
  font-weight: 600;
  line-height: 42px;
  text-align: center;
  margin: 2rem;
`;

export const FormLabel = ({ label }) => {
  return <FormLabelStyled>{label}</FormLabelStyled>;
};
